using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BODeploymentProcess: AbstractBusinessObject
        {
                public BODeploymentProcess() : base()
                {
                }

                public void SetProperties(string id,
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
    <Hash>21aed9853e92f776b62a054e8710069d</Hash>
</Codenesium>*/