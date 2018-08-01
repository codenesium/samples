using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiStudentResponseModel : AbstractApiResponseModel
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
			int studioId)
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
			this.StudioId = studioId;

			this.FamilyIdEntity = nameof(ApiResponse.Families);
			this.StudioIdEntity = nameof(ApiResponse.Studios);
		}

		[Required]
		[JsonProperty]
		public DateTime Birthday { get; private set; }

		[Required]
		[JsonProperty]
		public string Email { get; private set; }

		[Required]
		[JsonProperty]
		public bool EmailRemindersEnabled { get; private set; }

		[Required]
		[JsonProperty]
		public int FamilyId { get; private set; }

		[JsonProperty]
		public string FamilyIdEntity { get; set; }

		[Required]
		[JsonProperty]
		public string FirstName { get; private set; }

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public bool IsAdult { get; private set; }

		[Required]
		[JsonProperty]
		public string LastName { get; private set; }

		[Required]
		[JsonProperty]
		public string Phone { get; private set; }

		[Required]
		[JsonProperty]
		public bool SmsRemindersEnabled { get; private set; }

		[Required]
		[JsonProperty]
		public int StudioId { get; private set; }

		[JsonProperty]
		public string StudioIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>fbf77ef7ba2faa4a2e44a880400c3150</Hash>
</Codenesium>*/