using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("ProjectTrigger", Schema="dbo")]
        public partial class ProjectTrigger : AbstractEntity
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
                [Column("Id")]
                public string Id { get; private set; }

                [Column("IsDisabled")]
                public bool IsDisabled { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("ProjectId")]
                public string ProjectId { get; private set; }

                [Column("TriggerType")]
                public string TriggerType { get; private set; }
        }
}

/*<Codenesium>
    <Hash>77a2fd36ef5842650c8ed44e77f18cca</Hash>
</Codenesium>*/