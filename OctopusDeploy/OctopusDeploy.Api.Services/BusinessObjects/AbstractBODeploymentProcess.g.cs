using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBODeploymentProcess: AbstractBusinessObject
        {
                public AbstractBODeploymentProcess() : base()
                {
                }

                public virtual void SetProperties(string id,
                                                  bool isFrozen,
                                                  string jSON,
                                                  string ownerId,
                                                  string relatedDocumentIds,
                                                  int version)
                {
                        this.Id = id;
                        this.IsFrozen = isFrozen;
                        this.JSON = jSON;
                        this.OwnerId = ownerId;
                        this.RelatedDocumentIds = relatedDocumentIds;
                        this.Version = version;
                }

                public string Id { get; private set; }

                public bool IsFrozen { get; private set; }

                public string JSON { get; private set; }

                public string OwnerId { get; private set; }

                public string RelatedDocumentIds { get; private set; }

                public int Version { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a85ddbfc0e546c4d805ba9606048d705</Hash>
</Codenesium>*/