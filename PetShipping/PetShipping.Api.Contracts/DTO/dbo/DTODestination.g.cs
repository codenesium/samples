using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTODestination: AbstractDTO
	{
		public DTODestination() : base()
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

		public int CountryId { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }
	}
}

/*<Codenesium>
    <Hash>17a6dda44949d73f2fc9c308165b0745</Hash>
</Codenesium>*/