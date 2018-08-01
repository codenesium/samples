using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOProxy : AbstractBusinessObject
	{
		public AbstractBOProxy()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  string jSON,
		                                  string name)
		{
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
		}

		public string Id { get; private set; }

		public string JSON { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b5af6656979e4e20acadad03843082eb</Hash>
</Codenesium>*/