using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOActionTemplateVersion: AbstractBusinessObject
        {
                public BOActionTemplateVersion() : base()
                {
                }

                public void SetProperties(string id,
                                          string actionType,
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

                public string ActionType { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string LatestActionTemplateId { get; private set; }

                public string Name { get; private set; }

                public int Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c95120e91169f3be1665d8f72f643abb</Hash>
</Codenesium>*/