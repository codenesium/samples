using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBODestination : AbstractBusinessObject
	{
		public AbstractBODestination()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int countryId,
		                                  string name,
		                                  int order)
		{
			this.CountryId = countryId;
			this.Id = id;
			this.Name = name;
			this.Order = order;
		}

		public int CountryId { get; private set; }

		public int Id { get; private set; }

		public string Name { get; private set; }

		public int Order { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f38e704cf6eab1e2b3ed2016c3851d03</Hash>
</Codenesium>*/