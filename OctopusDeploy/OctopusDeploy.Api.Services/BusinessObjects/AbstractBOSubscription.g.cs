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
    <Hash>9ab14cb954bfc8a96d5e9a26428e37fc</Hash>
</Codenesium>*/