using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
	public partial class BOHandler: AbstractBusinessObject
	{
		public BOHandler() : base()
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

		public int CountryId { get; private set; }
		public string Email { get; private set; }
		public string FirstName { get; private set; }
		public int Id { get; private set; }
		public string LastName { get; private set; }
		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>690f5c0b83d9915f54d8de0e88dd9110</Hash>
</Codenesium>*/