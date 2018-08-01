using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOLifecycle : AbstractBusinessObject
	{
		public AbstractBOLifecycle()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  byte[] dataVersion,
		                                  string jSON,
		                                  string name)
		{
			this.DataVersion = dataVersion;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
		}

		public byte[] DataVersion { get; private set; }

		public string Id { get; private set; }

		public string JSON { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2b432b200e2720ddf7f3438dc6374159</Hash>
</Codenesium>*/