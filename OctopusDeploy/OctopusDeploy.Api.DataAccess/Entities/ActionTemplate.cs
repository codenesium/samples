using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("ActionTemplate", Schema="dbo")]
        public partial class ActionTemplate : AbstractEntity
        {
                public ActionTemplate()
                {
                }

                public void SetProperties(
                        string actionType,
                        string communityActionTemplateId,
                        string id,
                        string jSON,
                        string name,
                        int version)
                {
                        this.ActionType = actionType;
                        this.CommunityActionTemplateId = communityActionTemplateId;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.Version = version;
                }

                [Column("ActionType")]
                public string ActionType { get; private set; }

                [Column("CommunityActionTemplateId")]
                public string CommunityActionTemplateId { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("Version")]
                public int Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b0cf8f588a5abc2cfb599fdf7b7771bc</Hash>
</Codenesium>*/