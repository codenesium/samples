using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
			string primaryContactPhone)
		{
			this.Note = note;
			this.PrimaryContactEmail = primaryContactEmail;
			this.PrimaryContactFirstName = primaryContactFirstName;
			this.PrimaryContactLastName = primaryContactLastName;
			this.PrimaryContactPhone = primaryContactPhone;
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
	}
}

/*<Codenesium>
    <Hash>14e30ec91f71bf7ee017c1dc76cc6fad</Hash>
</Codenesium>*/