using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class ApiFamilyServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiFamilyServerRequestModel()
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
    <Hash>7605b4205bfe3101f8423f0984f0e220</Hash>
</Codenesium>*/