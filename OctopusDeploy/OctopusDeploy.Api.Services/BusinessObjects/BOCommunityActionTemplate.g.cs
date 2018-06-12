using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOCommunityActionTemplate: AbstractBusinessObject
        {
                public BOCommunityActionTemplate() : base()
                {
                }

                public void SetProperties(string id,
                                          Guid externalId,
                                          string jSON,
                                          string name)
                {
                        this.ExternalId = externalId;
                        this.Id = id;
                        this.JSON = jSON;
                        this.Name = name;
                }

                public Guid ExternalId { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9e8aa79a46cb0231ebeef54bc01004d3</Hash>
</Codenesium>*/