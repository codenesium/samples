using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("ProjectTrigger", Schema="dbo")]
        public partial class ProjectTrigger: AbstractEntity
        {
                public ProjectTrigger()
                {
                }

                public void SetProperties(
                        string id,
                        bool isDisabled,
                        string jSON,
                        string name,
                        string projectId,
                        string triggerType)
                {
                        this.Id = id;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.Name = name;
                        this.ProjectId = projectId;
                        this.TriggerType = triggerType;
                }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("IsDisabled", TypeName="bit")]
                public bool IsDisabled { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("ProjectId", TypeName="nvarchar(50)")]
                public string ProjectId { get; private set; }

                [Column("TriggerType", TypeName="nvarchar(50)")]
                public string TriggerType { get; private set; }
        }
}

/*<Codenesium>
    <Hash>72c35eda2a9203126df7a2619a4b1adc</Hash>
</Codenesium>*/