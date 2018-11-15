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

		[JsonProperty]
		public string PrimaryContactPhone { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>5aa67cf04f4640fdcb1ab7a9ba1037e1</Hash>
</Codenesium>*/