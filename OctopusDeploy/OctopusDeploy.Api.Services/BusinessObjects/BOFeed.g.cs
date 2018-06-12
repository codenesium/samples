using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public partial class BOFeed:AbstractBusinessObject
        {
                public BOFeed() : base()
                {
                }

                public void SetProperties(string id,
                                          string feedType,
                                          string feedUri,
                                          string jSON,
                                          string name)
                {
                        this.FeedType = feedType;
                        this.FeedUri = feedUri;
                        this.Id = id;
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
    <Hash>4f07f318a09ba7f46c87be2514a959e9</Hash>
</Codenesium>*/