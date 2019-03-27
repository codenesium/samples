using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiFamilyClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiFamilyClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string notes,
			string primaryContactEmail,
			string primaryContactFirstName,
			string primaryContactLastName,
			string primaryContactPhone)
		{
			this.Notes = notes;
			this.PrimaryContactEmail = primaryContactEmail;
			this.PrimaryContactFirstName = primaryContactFirstName;
			this.PrimaryContactLastName = primaryContactLastName;
			this.PrimaryContactPhone = primaryContactPhone;
		}

		[JsonProperty]
		public string Notes { get; private set; } = default(string);

		[JsonProperty]
		public string PrimaryContactEmail { get; private set; } = default(string);

		[JsonProperty]
		public string PrimaryContactFirstName { get; private set; } = default(string);

		[JsonProperty]
		public string PrimaryContactLastName { get; private set; } = default(string);

		[JsonProperty]
		public string PrimaryContactPhone { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>9e6ea77a733b7c03b8ac9e1684286b6d</Hash>
</Codenesium>*/