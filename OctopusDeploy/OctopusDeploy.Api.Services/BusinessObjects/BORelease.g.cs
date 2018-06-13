using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BORelease: AbstractBusinessObject
        {
                public BORelease() : base()
                {
                }

                public void SetProperties(string id,
                                          DateTimeOffset assembled,
                                          string channelId,
                                          string jSON,
                                          string projectDeploymentProcessSnapshotId,
                                          string projectId,
                                          string projectVariableSetSnapshotId,
                                          string version)
                {
                        this.Assembled = assembled;
                        this.ChannelId = channelId;
                        this.Id = id;
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
    <Hash>0242f5ecded68f47beb054b9bc80224e</Hash>
</Codenesium>*/