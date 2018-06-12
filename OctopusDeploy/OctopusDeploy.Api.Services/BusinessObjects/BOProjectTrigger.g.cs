using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOProjectTrigger: AbstractBusinessObject
        {
                public BOProjectTrigger() : base()
                {
                }

                public void SetProperties(string id,
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

                public string Id { get; private set; }

                public bool IsDisabled { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public string ProjectId { get; private set; }

                public string TriggerType { get; private set; }
        }
}

/*<Codenesium>
    <Hash>da22949ffa814d2d94eda09d51b134bf</Hash>
</Codenesium>*/