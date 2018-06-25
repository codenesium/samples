using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiProjectRequestModel : AbstractApiRequestModel
        {
                public ApiProjectRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        bool autoCreateRelease,
                        byte[] dataVersion,
                        string deploymentProcessId,
                        bool discreteChannelRelease,
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
                        this.IncludedLibraryVariableSetIds = includedLibraryVariableSetIds;
                        this.IsDisabled = isDisabled;
                        this.JSON = jSON;
                        this.LifecycleId = lifecycleId;
                        this.Name = name;
                        this.ProjectGroupId = projectGroupId;
                        this.Slug = slug;
                        this.VariableSetId = variableSetId;
                }

                private bool autoCreateRelease;

                [Required]
                public bool AutoCreateRelease
                {
                        get
                        {
                                return this.autoCreateRelease;
                        }

                        set
                        {
                                this.autoCreateRelease = value;
                        }
                }

                private byte[] dataVersion;

                [Required]
                public byte[] DataVersion
                {
                        get
                        {
                                return this.dataVersion;
                        }

                        set
                        {
                                this.dataVersion = value;
                        }
                }

                private string deploymentProcessId;

                public string DeploymentProcessId
                {
                        get
                        {
                                return this.deploymentProcessId;
                        }

                        set
                        {
                                this.deploymentProcessId = value;
                        }
                }

                private bool discreteChannelRelease;

                [Required]
                public bool DiscreteChannelRelease
                {
                        get
                        {
                                return this.discreteChannelRelease;
                        }

                        set
                        {
                                this.discreteChannelRelease = value;
                        }
                }

                private string includedLibraryVariableSetIds;

                public string IncludedLibraryVariableSetIds
                {
                        get
                        {
                                return this.includedLibraryVariableSetIds;
                        }

                        set
                        {
                                this.includedLibraryVariableSetIds = value;
                        }
                }

                private bool isDisabled;

                [Required]
                public bool IsDisabled
                {
                        get
                        {
                                return this.isDisabled;
                        }

                        set
                        {
                                this.isDisabled = value;
                        }
                }

                private string jSON;

                [Required]
                public string JSON
                {
                        get
                        {
                                return this.jSON;
                        }

                        set
                        {
                                this.jSON = value;
                        }
                }

                private string lifecycleId;

                [Required]
                public string LifecycleId
                {
                        get
                        {
                                return this.lifecycleId;
                        }

                        set
                        {
                                this.lifecycleId = value;
                        }
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private string projectGroupId;

                [Required]
                public string ProjectGroupId
                {
                        get
                        {
                                return this.projectGroupId;
                        }

                        set
                        {
                                this.projectGroupId = value;
                        }
                }

                private string slug;

                [Required]
                public string Slug
                {
                        get
                        {
                                return this.slug;
                        }

                        set
                        {
                                this.slug = value;
                        }
                }

                private string variableSetId;

                public string VariableSetId
                {
                        get
                        {
                                return this.variableSetId;
                        }

                        set
                        {
                                this.variableSetId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>e1b3f20aacb217b8ae46355c75cf9bd8</Hash>
</Codenesium>*/