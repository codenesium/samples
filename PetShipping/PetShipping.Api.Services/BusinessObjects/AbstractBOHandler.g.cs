using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOHandler : AbstractBusinessObject
	{
		public AbstractBOHandler()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int countryId,
		                                  string email,
		                                  string firstName,
		                                  string lastName,
		                                  string phone)
		{
			this.CountryId = countryId;
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id;
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
    <Hash>d1e31787761fce07ca4b5e60e798af8e</Hash>
</Codenesium>*/