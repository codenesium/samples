using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractBOFeed : AbstractBusinessObject
        {
                public AbstractBOFeed()
                        : base()
                {
                }

                public virtual void SetProperties(string id,
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
    <Hash>2f89349db5e763b9b9299bdd15bc015c</Hash>
</Codenesium>*/