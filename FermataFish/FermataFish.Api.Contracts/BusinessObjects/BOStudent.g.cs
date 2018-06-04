using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class BOStudent: AbstractBusinessObject
	{
		public BOStudent() : base()
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

		public DateTime Birthday { get; private set; }
		public string Email { get; private set; }
		public bool EmailRemindersEnabled { get; private set; }
		public int FamilyId { get; private set; }
		public string FirstName { get; private set; }
		public int Id { get; private set; }
		public bool IsAdult { get; private set; }
		public string LastName { get; private set; }
		public string Phone { get; private set; }
		public bool SmsRemindersEnabled { get; private set; }
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4394d43fd019a9bae1555b29e3d43b6e</Hash>
</Codenesium>*/