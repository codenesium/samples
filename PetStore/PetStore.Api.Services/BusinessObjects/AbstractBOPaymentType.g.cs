using Codenesium.DataConversionExtensions;
using System;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractBOPaymentType : AbstractBusinessObject
	{
		public AbstractBOPaymentType()
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
    <Hash>ab2f727b29a11eed6e82de03f7f001b2</Hash>
</Codenesium>*/