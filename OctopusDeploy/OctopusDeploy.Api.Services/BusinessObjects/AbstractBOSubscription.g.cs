using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOSubscription : AbstractBusinessObject
	{
		public AbstractBOSubscription()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  bool isDisabled,
		                                  string jSON,
		                                  string name,
		                                  string type)
		{
			this.Id = id;
			this.IsDisabled = isDisabled;
			this.JSON = jSON;
			this.Name = name;
			this.Type = type;
		}

		public string Id { get; private set; }

		public bool IsDisabled { get; private set; }

		public string JSON { get; private set; }

		public string Name { get; private set; }

		public string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>090ffa5168fb1912eb36daf6141f3158</Hash>
</Codenesium>*/