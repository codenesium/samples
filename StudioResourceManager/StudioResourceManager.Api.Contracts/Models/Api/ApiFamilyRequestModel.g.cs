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
			string primaryContactPhone)
		{
			this.Note = note;
			this.PrimaryContactEmail = primaryContactEmail;
			this.PrimaryContactFirstName = primaryContactFirstName;
			this.PrimaryContactLastName = primaryContactLastName;
			this.PrimaryContactPhone = primaryContactPhone;
		}

		[JsonProperty]
		public string Note { get; private set; }

		[JsonProperty]
		public string PrimaryContactEmail { get; private set; }

		[JsonProperty]
		public string PrimaryContactFirstName { get; private set; }

		[JsonProperty]
		public string PrimaryContactLastName { get; private set; }

		[Required]
		[JsonProperty]
		public string PrimaryContactPhone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>234cd5ae5cb8f6d2b5fcc6ff008e76a6</Hash>
</Codenesium>*/