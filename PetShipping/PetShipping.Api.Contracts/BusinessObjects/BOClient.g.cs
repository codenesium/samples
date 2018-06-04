using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class BOClient: AbstractBusinessObject
	{
		public BOClient() : base()
		{}

		public void SetProperties(int id,
		                          string email,
		                          string firstName,
		                          string lastName,
		                          string notes,
		                          string phone)
		{
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.LastName = lastName;
			this.Notes = notes;
			this.Phone = phone;
		}

		public string Email { get; private set; }
		public string FirstName { get; private set; }
		public int Id { get; private set; }
		public string LastName { get; private set; }
		public string Notes { get; private set; }
		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9d2e64c8555aab15a04e5277ef54da7f</Hash>
</Codenesium>*/