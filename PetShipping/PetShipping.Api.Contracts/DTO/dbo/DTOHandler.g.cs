using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOHandler: AbstractDTO
	{
		public DTOHandler() : base()
		{}

		public void SetProperties(int id,
		                          int countryId,
		                          string email,
		                          string firstName,
		                          string lastName,
		                          string phone)
		{
			this.CountryId = countryId.ToInt();
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.LastName = lastName;
			this.Phone = phone;
		}

		public int CountryId { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public int Id { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
	}
}

/*<Codenesium>
    <Hash>9b6eb05cf9bc7f423db28e020b9c8b60</Hash>
</Codenesium>*/