using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("ActionTemplateVersion", Schema="dbo")]
        public partial class ActionTemplateVersion: AbstractEntity
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

                [Column("ActionType", TypeName="nvarchar(50)")]
                public string ActionType { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("LatestActionTemplateId", TypeName="nvarchar(50)")]
                public string LatestActionTemplateId { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("Version", TypeName="int")]
                public int Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2faffb7b1941e8fc48a70be69f47689f</Hash>
</Codenesium>*/