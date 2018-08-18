using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOProjectGroup : AbstractBusinessObject
	{
		public AbstractBOProjectGroup()
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
    <Hash>fa89ab3e021343f4b16ab5425d2db97a</Hash>
</Codenesium>*/