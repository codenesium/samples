using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiCommunityActionTemplateResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        Guid externalId,
                        string jSON,
                        string name)
                {
                        this.Id = id;
                        this.ExternalId = externalId;
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
    <Hash>167460c888cb4391c624ba001fc3b67c</Hash>
</Codenesium>*/