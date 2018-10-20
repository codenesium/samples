using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiFamilyRequestModel : AbstractApiRequestModel
	{
		public ApiFamilyRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string note,
			string primaryContactEmail,
			string primaryContactFirstName,
			string primaryContactLastName,
			string primaryContactPhone,
			bool isDeleted)
		{
			this.Note = note;
			this.PrimaryContactEmail = primaryContactEmail;
			this.PrimaryContactFirstName = primaryContactFirstName;
			this.PrimaryContactLastName = primaryContactLastName;
			this.PrimaryContactPhone = primaryContactPhone;
			this.IsDeleted = isDeleted;
		}

		[JsonProperty]
		public string Note { get; private set; } = default(string);

		[JsonProperty]
		public string PrimaryContactEmail { get; private set; } = default(string);

		[JsonProperty]
		public string PrimaryContactFirstName { get; private set; } = default(string);

		[JsonProperty]
		public string PrimaryContactLastName { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public string PrimaryContactPhone { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public bool IsDeleted { get; private set; } = default(bool);
	}
}

/*<Codenesium>
    <Hash>e7e8fdb2a6d6712d8a82dfa2105c0ea0</Hash>
</Codenesium>*/