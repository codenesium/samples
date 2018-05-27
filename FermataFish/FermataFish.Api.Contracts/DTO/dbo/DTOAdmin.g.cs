using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTOAdmin: AbstractDTO
	{
		public DTOAdmin() : base()
		{}

		public void SetProperties(int id,
		                          Nullable<DateTime> birthday,
		                          string email,
		                          string firstName,
		                          string lastName,
		                          string phone,
		                          int studioId)
		{
			this.Birthday = birthday.ToNullableDateTime();
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.LastName = lastName;
			this.Phone = phone;
			this.StudioId = studioId.ToInt();
		}

		public Nullable<DateTime> Birthday { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public int Id { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public int StudioId { get; set; }
	}
}

/*<Codenesium>
    <Hash>4e1a94bc0f7a4f8e075d44552063bd1c</Hash>
</Codenesium>*/