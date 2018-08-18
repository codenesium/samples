using Codenesium.DataConversionExtensions;
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
    <Hash>333e622bb3de4462739618cc078508e4</Hash>
</Codenesium>*/