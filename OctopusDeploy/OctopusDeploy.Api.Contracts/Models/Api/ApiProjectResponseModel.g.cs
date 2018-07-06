using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiProjectResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
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
                        this.Id = id;
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

                public bool AutoCreateRelease { get; private set; }

                public byte[] DataVersion { get; private set; }

                public string DeploymentProcessId { get; private set; }

                public bool DiscreteChannelRelease { get; private set; }

                public string Id { get; private set; }

                public string IncludedLibraryVariableSetIds { get; private set; }

                public bool IsDisabled { get; private set; }

                public string JSON { get; private set; }

                public string LifecycleId { get; private set; }

                public string Name { get; private set; }

                public string ProjectGroupId { get; private set; }

                public string Slug { get; private set; }

                public string VariableSetId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e527635c95a273096191dfea718c6598</Hash>
</Codenesium>*/