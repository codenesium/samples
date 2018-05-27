using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTOTeacher: AbstractDTO
	{
		public DTOTeacher() : base()
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

		public DateTime Birthday { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public int Id { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public int StudioId { get; set; }
	}
}

/*<Codenesium>
    <Hash>28fd78e76e2438327d91417fcd4a2f2c</Hash>
</Codenesium>*/