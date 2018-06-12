using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOActionTemplate: AbstractBusinessObject
        {
                public BOActionTemplate() : base()
                {
                }

                public void SetProperties(string id,
                                          string actionType,
                                          string communityActionTemplateId,
                                          string jSON,
                                          string name,
                                          int version)
                {
                        this.ActionType = actionType;
                        this.CommunityActionTemplateId = communityActionTemplateId;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                        this.Version = version;
                }

                public string ActionType { get; private set; }

                public string CommunityActionTemplateId { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }

                public int Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a7ee301cece735957c78ae978dee4927</Hash>
</Codenesium>*/