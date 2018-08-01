using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOMutex : AbstractBusinessObject
	{
		public AbstractBOMutex()
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
    <Hash>a7b877d8f02e64bd2aa984df12c24fc3</Hash>
</Codenesium>*/