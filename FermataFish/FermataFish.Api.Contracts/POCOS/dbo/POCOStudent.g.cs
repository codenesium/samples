using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace FermataFishNS.Api.Contracts
{
	public partial class POCOStudent
	{
		public POCOStudent()
		{}

		public POCOStudent(
			int id,
			string email,
			string firstName,
			string lastName,
			string phone,
			bool isAdult,
			DateTime birthday,
			int familyId,
			int studioId,
			bool smsRemindersEnabled,
			bool emailRemindersEnabled)
		{
			this.Id = id.ToInt();
			this.Email = email.ToString();
			this.FirstName = firstName.ToString();
			this.LastName = lastName.ToString();
			this.Phone = phone.ToString();
			this.IsAdult = isAdult.ToBoolean();
			this.Birthday = birthday.ToDateTime();
			this.SmsRemindersEnabled = smsRemindersEnabled.ToBoolean();
			this.EmailRemindersEnabled = emailRemindersEnabled.ToBoolean();

			this.FamilyId = new ReferenceEntity<int>(familyId,
			                                         nameof(ApiResponse.Families));
			this.StudioId = new ReferenceEntity<int>(studioId,
			                                         nameof(ApiResponse.Studios));
		}

		public int Id { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public bool IsAdult { get; set; }
		public DateTime Birthday { get; set; }
		public ReferenceEntity<int> FamilyId { get; set; }
		public ReferenceEntity<int> StudioId { get; set; }
		public bool SmsRemindersEnabled { get; set; }
		public bool EmailRemindersEnabled { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailValue { get; set; } = true;

		public bool ShouldSerializeEmail()
		{
			return this.ShouldSerializeEmailValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFirstNameValue { get; set; } = true;

		public bool ShouldSerializeFirstName()
		{
			return this.ShouldSerializeFirstNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLastNameValue { get; set; } = true;

		public bool ShouldSerializeLastName()
		{
			return this.ShouldSerializeLastNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePhoneValue { get; set; } = true;

		public bool ShouldSerializePhone()
		{
			return this.ShouldSerializePhoneValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIsAdultValue { get; set; } = true;

		public bool ShouldSerializeIsAdult()
		{
			return this.ShouldSerializeIsAdultValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBirthdayValue { get; set; } = true;

		public bool ShouldSerializeBirthday()
		{
			return this.ShouldSerializeBirthdayValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFamilyIdValue { get; set; } = true;

		public bool ShouldSerializeFamilyId()
		{
			return this.ShouldSerializeFamilyIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStudioIdValue { get; set; } = true;

		public bool ShouldSerializeStudioId()
		{
			return this.ShouldSerializeStudioIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSmsRemindersEnabledValue { get; set; } = true;

		public bool ShouldSerializeSmsRemindersEnabled()
		{
			return this.ShouldSerializeSmsRemindersEnabledValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailRemindersEnabledValue { get; set; } = true;

		public bool ShouldSerializeEmailRemindersEnabled()
		{
			return this.ShouldSerializeEmailRemindersEnabledValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeEmailValue = false;
			this.ShouldSerializeFirstNameValue = false;
			this.ShouldSerializeLastNameValue = false;
			this.ShouldSerializePhoneValue = false;
			this.ShouldSerializeIsAdultValue = false;
			this.ShouldSerializeBirthdayValue = false;
			this.ShouldSerializeFamilyIdValue = false;
			this.ShouldSerializeStudioIdValue = false;
			this.ShouldSerializeSmsRemindersEnabledValue = false;
			this.ShouldSerializeEmailRemindersEnabledValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>7bcd2f49efbba6d946d6cf8034a9b41d</Hash>
</Codenesium>*/