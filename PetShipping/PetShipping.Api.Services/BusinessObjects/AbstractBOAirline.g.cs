using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOAirline : AbstractBusinessObject
	{
		public AbstractBOAirline()
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
    <Hash>ae7a17b8d6d76aa30a1d0f6b9874f06e</Hash>
</Codenesium>*/