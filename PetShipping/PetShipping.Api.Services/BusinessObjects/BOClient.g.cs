using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
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
    <Hash>e8b762d2ed7c8456fd2ead875b47fe72</Hash>
</Codenesium>*/