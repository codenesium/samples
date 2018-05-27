using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class DTOClient: AbstractDTO
	{
		public DTOClient() : base()
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

		public string Email { get; set; }
		public string FirstName { get; set; }
		public int Id { get; set; }
		public string LastName { get; set; }
		public string Notes { get; set; }
		public string Phone { get; set; }
	}
}

/*<Codenesium>
    <Hash>9547691fd766d5b2997a93bd91d93e7c</Hash>
</Codenesium>*/