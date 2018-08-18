using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiStudentRequestModel : AbstractApiRequestModel
	{
		public ApiStudentRequestModel()
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
			int studioId)
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
			this.StudioId = studioId;
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
		public string FirstName { get; private set; }

		[JsonProperty]
		public bool IsAdult { get; private set; }

		[JsonProperty]
		public string LastName { get; private set; }

		[JsonProperty]
		public string Phone { get; private set; }

		[JsonProperty]
		public bool SmsRemindersEnabled { get; private set; }

		[JsonProperty]
		public int StudioId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>557c78c01d8e0a3762a7234377c22be9</Hash>
</Codenesium>*/