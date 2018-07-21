using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Project", Schema="dbo")]
        public partial class Project : AbstractEntity
        {
                public Project()
                {
                }

                public virtual void SetProperties(
                        bool autoCreateRelease,
                        byte[] dataVersion,
                        string deploymentProcessId,
                        bool discreteChannelRelease,
                        string id,
                        string includedLibraryVariableSetIds,
                        bool isDisabled,
                        string jSON,
                        string lifecycleId,
                        string name,
                        string projectGroupId,
                        string slug,
                        string variableSetId)
                {
                        this.AutoCreateRelease = autoCreateRelease;
                        this.DataVersion = dataVersion;
                        this.DeploymentProcessId = deploymentProcessId;
                        this.DiscreteChannelRelease = discreteChannelRelease;
                        this.Id = id;
                        this.IncludedLibraryVariableSetIds = includedLibraryVariableSetIds;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.LifecycleId = lifecycleId;
                        this.Name = name;
                        this.ProjectGroupId = projectGroupId;
                        this.Slug = slug;
                        this.VariableSetId = variableSetId;
                }

                [Column("AutoCreateRelease")]
                public bool AutoCreateRelease { get; private set; }

                [Column("DataVersion")]
                public byte[] DataVersion { get; private set; }

                [Column("DeploymentProcessId")]
                public string DeploymentProcessId { get; private set; }

                [Column("DiscreteChannelRelease")]
                public bool DiscreteChannelRelease { get; private set; }

                [Key]
                [Column("Id")]
                public string Id { get; private set; }

                [Column("IncludedLibraryVariableSetIds")]
                public string IncludedLibraryVariableSetIds { get; private set; }

                [Column("IsDisabled")]
                public bool IsDisabled { get; private set; }

                [Column("JSON")]
                public string JSON { get; private set; }

                [Column("LifecycleId")]
                public string LifecycleId { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Column("ProjectGroupId")]
                public string ProjectGroupId { get; private set; }

                [Column("Slug")]
                public string Slug { get; private set; }

                [Column("VariableSetId")]
                public string VariableSetId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ed4ef73db8088b158e65643fd6b75491</Hash>
</Codenesium>*/