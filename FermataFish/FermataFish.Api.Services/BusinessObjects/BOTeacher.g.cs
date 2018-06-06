using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
	public partial class BOTeacher: AbstractBusinessObject
	{
		public BOTeacher() : base()
		{}

		public void SetProperties(int id,
		                          DateTime birthday,
		                          string email,
		                          string firstName,
		                          string lastName,
		                          string phone,
		                          int studioId)
		{
			this.Birthday = birthday.ToDateTime();
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.LastName = lastName;
			this.Phone = phone;
			this.StudioId = studioId.ToInt();
		}

		public DateTime Birthday { get; private set; }
		public string Email { get; private set; }
		public string FirstName { get; private set; }
		public int Id { get; private set; }
		public string LastName { get; private set; }
		public string Phone { get; private set; }
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1e116e2dc1498c74245af38d62bf2827</Hash>
</Codenesium>*/