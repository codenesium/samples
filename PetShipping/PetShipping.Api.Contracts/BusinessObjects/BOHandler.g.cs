using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
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
    <Hash>df87e8c38b76f71c70389fdf61a3dbd9</Hash>
</Codenesium>*/