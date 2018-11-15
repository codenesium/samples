using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial class ApiStudentClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime birthday,
			string email,
			bool emailRemindersEnabled,
			int familyId,
			string firstName,
			bool isAdult,
			string lastName,
			string phone,
			bool smsRemindersEnabled,
			int userId)
		{
			this.Id = id;
			this.Birthday = birthday;
			this.Email = email;
			this.EmailRemindersEnabled = emailRemindersEnabled;
			this.FamilyId = familyId;
			this.FirstName = firstName;
			this.IsAdult = isAdult;
			this.LastName = lastName;
			this.Phone = phone;
			this.SmsRemindersEnabled = smsRemindersEnabled;
			this.UserId = userId;

			this.FamilyIdEntity = nameof(ApiResponse.Families);
			this.UserIdEntity = nameof(ApiResponse.Users);
		}

		[JsonProperty]
		public DateTime Birthday { get; private set; }

		[JsonProperty]
		public string Email { get; private set; }

		[JsonProperty]
		public bool EmailRemindersEnabled { get; private set; }

		[JsonProperty]
		public int FamilyId { get; private set; }

		[JsonProperty]
		public string FamilyIdEntity { get; set; }

		[JsonProperty]
		public string FirstName { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public bool IsAdult { get; private set; }

		[JsonProperty]
		public string LastName { get; private set; }

		[JsonProperty]
		public string Phone { get; private set; }

		[JsonProperty]
		public bool SmsRemindersEnabled { get; private set; }

		[JsonProperty]
		public int UserId { get; private set; }

		[JsonProperty]
		public string UserIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>f5d0610f4fb5770401f2eef4b6a1b7c6</Hash>
</Codenesium>*/