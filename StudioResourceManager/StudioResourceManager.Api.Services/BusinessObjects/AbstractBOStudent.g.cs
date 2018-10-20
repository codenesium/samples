using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractBOStudent : AbstractBusinessObject
	{
		public AbstractBOStudent()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  DateTime birthday,
		                                  string email,
		                                  bool emailRemindersEnabled,
		                                  int familyId,
		                                  string firstName,
		                                  bool isAdult,
		                                  string lastName,
		                                  string phone,
		                                  bool smsRemindersEnabled,
		                                  int userId,
		                                  bool isDeleted)
		{
			this.Birthday = birthday;
			this.Email = email;
			this.EmailRemindersEnabled = emailRemindersEnabled;
			this.FamilyId = familyId;
			this.FirstName = firstName;
			this.Id = id;
			this.IsAdult = isAdult;
			this.LastName = lastName;
			this.Phone = phone;
			this.SmsRemindersEnabled = smsRemindersEnabled;
			this.UserId = userId;
			this.IsDeleted = isDeleted;
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

		public int UserId { get; private set; }

		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>12bbb7df78f5b274c6b4e77ff1abb455</Hash>
</Codenesium>*/