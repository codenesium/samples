using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class DTOStudent: AbstractDTO
	{
		public DTOStudent() : base()
		{}

		public void SetProperties(int id,
		                          DateTime birthday,
		                          string email,
		                          bool emailRemindersEnabled,
		                          int familyId,
		                          string firstName,
		                          bool isAdult,
		                          string lastName,
		                          string phone,
		                          bool smsRemindersEnabled,
		                          int studioId)
		{
			this.Birthday = birthday.ToDateTime();
			this.Email = email;
			this.EmailRemindersEnabled = emailRemindersEnabled.ToBoolean();
			this.FamilyId = familyId.ToInt();
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.IsAdult = isAdult.ToBoolean();
			this.LastName = lastName;
			this.Phone = phone;
			this.SmsRemindersEnabled = smsRemindersEnabled.ToBoolean();
			this.StudioId = studioId.ToInt();
		}

		public DateTime Birthday { get; set; }
		public string Email { get; set; }
		public bool EmailRemindersEnabled { get; set; }
		public int FamilyId { get; set; }
		public string FirstName { get; set; }
		public int Id { get; set; }
		public bool IsAdult { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public bool SmsRemindersEnabled { get; set; }
		public int StudioId { get; set; }
	}
}

/*<Codenesium>
    <Hash>f86bf586ab2b7a0ca85ee5e199c93c98</Hash>
</Codenesium>*/