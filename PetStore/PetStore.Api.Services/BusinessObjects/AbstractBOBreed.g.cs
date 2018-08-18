using Codenesium.DataConversionExtensions;
using System;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractBOBreed : AbstractBusinessObject
	{
		public AbstractBOBreed()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string name)
		{
			this.Id = id;
			this.Name = name;
		}

		public int Id { get; private set; }

		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>77fc0edff36424b5f51e6e6610a2d675</Hash>
</Codenesium>*/