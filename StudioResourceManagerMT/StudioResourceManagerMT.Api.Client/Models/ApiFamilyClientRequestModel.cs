using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>9182512339919baaba1f23648d1cb1f4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/