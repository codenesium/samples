using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class ApiStudentServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiStudentServerRequestModel()
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

		[Required]
		[JsonProperty]
		public DateTime Birthday { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Email { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public bool EmailRemindersEnabled { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public int FamilyId { get; private set; }

		[Required]
		[JsonProperty]
		public string FirstName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public bool IsAdult { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public string LastName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string Phone { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public bool SmsRemindersEnabled { get; private set; } = default(bool);

		[Required]
		[JsonProperty]
		public int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2a42b126e6f66ec64514f8b9c9242cb3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/