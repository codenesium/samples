using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOActionTemplate : AbstractBusinessObject
        {
                public AbstractBOActionTemplate()
                        : base()
                {
                }

                public virtual void SetProperties(string id,
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
    <Hash>1ad83f1a7fcd78c5581f5fe19d630840</Hash>
</Codenesium>*/