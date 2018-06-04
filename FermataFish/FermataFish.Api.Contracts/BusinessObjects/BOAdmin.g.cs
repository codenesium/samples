using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class BOAdmin: AbstractBusinessObject
	{
		public BOAdmin() : base()
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

		public Nullable<DateTime> Birthday { get; private set; }
		public string Email { get; private set; }
		public string FirstName { get; private set; }
		public int Id { get; private set; }
		public string LastName { get; private set; }
		public string Phone { get; private set; }
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a72662d49a95205c503513f3705055a3</Hash>
</Codenesium>*/