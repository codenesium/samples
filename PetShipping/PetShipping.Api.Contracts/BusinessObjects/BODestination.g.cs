using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class BODestination: AbstractBusinessObject
	{
		public BODestination() : base()
		{}

		public void SetProperties(int id,
		                          int countryId,
		                          string name,
		                          int order)
		{
			this.CountryId = countryId.ToInt();
			this.Id = id.ToInt();
			this.Name = name;
			this.Order = order.ToInt();
		}

		public int CountryId { get; private set; }
		public int Id { get; private set; }
		public string Name { get; private set; }
		public int Order { get; private set; }
	}
}

/*<Codenesium>
    <Hash>35608afb703f89eca5868e5f4b99aa66</Hash>
</Codenesium>*/