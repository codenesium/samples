using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
        public partial class ApiFeedResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string id,
                        string feedType,
                        string feedUri,
                        string jSON,
                        string name)
                {
                        this.Id = id;
                        this.FeedType = feedType;
                        this.FeedUri = feedUri;
                        this.JSON = jSON;
                        this.Name = name;
                }

                public string FeedType { get; private set; }

                public string FeedUri { get; private set; }

                public string Id { get; private set; }

                public string JSON { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8c840afb6434d25cbd0c31c99979e759</Hash>
</Codenesium>*/