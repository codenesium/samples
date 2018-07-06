using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiReleaseResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        DateTimeOffset assembled,
                        string channelId,
                        string jSON,
                        string projectDeploymentProcessSnapshotId,
                        string projectId,
                        string projectVariableSetSnapshotId,
                        string version)
                {
                        this.Id = id;
                        this.Assembled = assembled;
                        this.ChannelId = channelId;
                        this.JSON = jSON;
                        this.ProjectDeploymentProcessSnapshotId = projectDeploymentProcessSnapshotId;
                        this.ProjectId = projectId;
                        this.ProjectVariableSetSnapshotId = projectVariableSetSnapshotId;
                        this.Version = version;
                }

                public DateTimeOffset Assembled { get; private set; }

                public string ChannelId { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string ProjectDeploymentProcessSnapshotId { get; private set; }

                public string ProjectId { get; private set; }

                public string ProjectVariableSetSnapshotId { get; private set; }

                public string Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a4a340f67aacf251207419ce65835402</Hash>
</Codenesium>*/