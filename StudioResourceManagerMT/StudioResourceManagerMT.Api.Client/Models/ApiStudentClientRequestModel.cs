using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
{
	public partial class ApiStudentClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiStudentClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
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
		}

		[JsonProperty]
		public DateTime Birthday { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[JsonProperty]
		public bool EmailRemindersEnabled { get; private set; } = default(bool);

		[JsonProperty]
		public int FamilyId { get; private set; }

		[JsonProperty]
		public string FirstName { get; private set; } = default(string);

		[JsonProperty]
		public bool IsAdult { get; private set; } = default(bool);

		[JsonProperty]
		public string LastName { get; private set; } = default(string);

		[JsonProperty]
		public string Phone { get; private set; } = default(string);

		[JsonProperty]
		public bool SmsRemindersEnabled { get; private set; } = default(bool);

		[JsonProperty]
		public int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c8ad28def2dd8114a1cf61b2657ab5b2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/