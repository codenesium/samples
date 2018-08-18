using Codenesium.DataConversionExtensions;
using System;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractBOPen : AbstractBusinessObject
	{
		public AbstractBOPen()
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
    <Hash>4872c9969b048b2dd41f74a28a0d2e9e</Hash>
</Codenesium>*/