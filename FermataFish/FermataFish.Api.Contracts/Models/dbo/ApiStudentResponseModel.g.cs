using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiStudentResponseModel: AbstractApiResponseModel
	{
		public ApiStudentResponseModel() : base()
		{}

		public void SetProperties(
			DateTime birthday,
			string email,
			bool emailRemindersEnabled,
			int familyId,
			string firstName,
			int id,
			bool isAdult,
			string lastName,
			string phone,
			bool smsRemindersEnabled,
			int studioId)
		{
			this.Birthday = birthday.ToDateTime();
			this.Email = email;
			this.EmailRemindersEnabled = emailRemindersEnabled.ToBoolean();
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.IsAdult = isAdult.ToBoolean();
			this.LastName = lastName;
			this.Phone = phone;
			this.SmsRemindersEnabled = smsRemindersEnabled.ToBoolean();

			this.FamilyId = new ReferenceEntity<int>(familyId,
			                                         nameof(ApiResponse.Families));
			this.StudioId = new ReferenceEntity<int>(studioId,
			                                         nameof(ApiResponse.Studios));
		}

		public DateTime Birthday { get; set; }
		public string Email { get; set; }
		public bool EmailRemindersEnabled { get; set; }
		public ReferenceEntity<int> FamilyId { get; set; }
		public string FirstName { get; set; }
		public int Id { get; set; }
		public bool IsAdult { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public bool SmsRemindersEnabled { get; set; }
		public ReferenceEntity<int> StudioId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBirthdayValue { get; set; } = true;

		public bool ShouldSerializeBirthday()
		{
			return this.ShouldSerializeBirthdayValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailValue { get; set; } = true;

		public bool ShouldSerializeEmail()
		{
			return this.ShouldSerializeEmailValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmailRemindersEnabledValue { get; set; } = true;

		public bool ShouldSerializeEmailRemindersEnabled()
		{
			return this.ShouldSerializeEmailRemindersEnabledValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFamilyIdValue { get; set; } = true;

		public bool ShouldSerializeFamilyId()
		{
			return this.ShouldSerializeFamilyIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeFirstNameValue { get; set; } = true;

		public bool ShouldSerializeFirstName()
		{
			return this.ShouldSerializeFirstNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIsAdultValue { get; set; } = true;

		public bool ShouldSerializeIsAdult()
		{
			return this.ShouldSerializeIsAdultValue;
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
		public bool ShouldSerializeSmsRemindersEnabledValue { get; set; } = true;

		public bool ShouldSerializeSmsRemindersEnabled()
		{
			return this.ShouldSerializeSmsRemindersEnabledValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStudioIdValue { get; set; } = true;

		public bool ShouldSerializeStudioId()
		{
			return this.ShouldSerializeStudioIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBirthdayValue = false;
			this.ShouldSerializeEmailValue = false;
			this.ShouldSerializeEmailRemindersEnabledValue = false;
			this.ShouldSerializeFamilyIdValue = false;
			this.ShouldSerializeFirstNameValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeIsAdultValue = false;
			this.ShouldSerializeLastNameValue = false;
			this.ShouldSerializePhoneValue = false;
			this.ShouldSerializeSmsRemindersEnabledValue = false;
			this.ShouldSerializeStudioIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>9f67d755cf36b6d90c44dadc689aaced</Hash>
</Codenesium>*/