using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("ActionTemplate", Schema="dbo")]
        public partial class ActionTemplate: AbstractEntity
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

                [Column("ActionType", TypeName="nvarchar(50)")]
                public string ActionType { get; private set; }

                [Column("CommunityActionTemplateId", TypeName="nvarchar(50)")]
                public string CommunityActionTemplateId { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("Version", TypeName="int")]
                public int Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9d40a2c69b26691551187e7713a3ff1c</Hash>
</Codenesium>*/