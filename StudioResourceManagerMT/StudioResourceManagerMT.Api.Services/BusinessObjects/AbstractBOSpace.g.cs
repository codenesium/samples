using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractBOSpace : AbstractBusinessObject
	{
		public AbstractBOSpace()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string description,
		                                  string name)
		{
			this.Description = description;
			this.Id = id;
			this.Name = name;
		}

		public string Description { get; private set; }

		public int Id { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1842adc418bd16f17f18c82902366d64</Hash>
</Codenesium>*/