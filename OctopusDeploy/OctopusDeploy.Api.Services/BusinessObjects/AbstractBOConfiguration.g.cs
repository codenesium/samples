using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOConfiguration : AbstractBusinessObject
	{
		public AbstractBOConfiguration()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  string jSON)
		{
			this.Id = id;
			this.JSON = jSON;
		}

		public string Id { get; private set; }

		public string JSON { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2f276668a5576076b4414496c9dcdf44</Hash>
</Codenesium>*/