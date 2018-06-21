using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("ActionTemplateVersion", Schema="dbo")]
        public partial class ActionTemplateVersion : AbstractEntity
        {
                public ActionTemplateVersion()
                {
                }

                public void SetProperties(
                        string actionType,
                        string id,
                        string jSON,
                        string latestActionTemplateId,
                        string name,
                        int version)
                {
                        this.ActionType = actionType;
                        this.Id = id;
                        this.JSON = jSON;
                        this.LatestActionTemplateId = latestActionTemplateId;
                        this.Name = name;
                        this.Version = version;
                }

                [Column("ActionType")]
                public string ActionType { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("LatestActionTemplateId")]
                public string LatestActionTemplateId { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("Version")]
                public int Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ece44ec841ee058433b83d11f04e3610</Hash>
</Codenesium>*/