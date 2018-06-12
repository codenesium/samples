using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace OctopusDeployNS.Api.DataAccess
{
        [Table("Project", Schema="dbo")]
        public partial class Project: AbstractEntity
        {
                public Project()
                {
                }

                public void SetProperties(
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

                [Column("AutoCreateRelease", TypeName="bit")]
                public bool AutoCreateRelease { get; private set; }

                [Column("DataVersion", TypeName="timestamp")]
                public byte[] DataVersion { get; private set; }

                [Column("DeploymentProcessId", TypeName="nvarchar(50)")]
                public string DeploymentProcessId { get; private set; }

                [Column("DiscreteChannelRelease", TypeName="bit")]
                public bool DiscreteChannelRelease { get; private set; }

                [Key]
                [Column("Id", TypeName="nvarchar(50)")]
                public string Id { get; private set; }

                [Column("IncludedLibraryVariableSetIds", TypeName="nvarchar(-1)")]
                public string IncludedLibraryVariableSetIds { get; private set; }

                [Column("IsDisabled", TypeName="bit")]
                public bool IsDisabled { get; private set; }

                [Column("JSON", TypeName="nvarchar(-1)")]
                public string JSON { get; private set; }

                [Column("LifecycleId", TypeName="nvarchar(50)")]
                public string LifecycleId { get; private set; }

                [Column("Name", TypeName="nvarchar(200)")]
                public string Name { get; private set; }

                [Column("ProjectGroupId", TypeName="nvarchar(50)")]
                public string ProjectGroupId { get; private set; }

                [Column("Slug", TypeName="nvarchar(210)")]
                public string Slug { get; private set; }

                [Column("VariableSetId", TypeName="nvarchar(150)")]
                public string VariableSetId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>3d16df896c5908e1a424b7fec9a5f760</Hash>
</Codenesium>*/