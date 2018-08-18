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
    <Hash>484f35b627f32621a6e075a919ee47d7</Hash>
</Codenesium>*/