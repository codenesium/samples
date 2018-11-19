using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Client
{
	public partial class ApiFamilyClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int id,
			string note,
			string primaryContactEmail,
			string primaryContactFirstName,
			string primaryContactLastName,
			string primaryContactPhone)
		{
			this.Id = id;
			this.Note = note;
			this.PrimaryContactEmail = primaryContactEmail;
			this.PrimaryContactFirstName = primaryContactFirstName;
			this.PrimaryContactLastName = primaryContactLastName;
			this.PrimaryContactPhone = primaryContactPhone;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Note { get; private set; }

		[JsonProperty]
		public string PrimaryContactEmail { get; private set; }

		[JsonProperty]
		public string PrimaryContactFirstName { get; private set; }

		[JsonProperty]
		public string PrimaryContactLastName { get; private set; }

		[JsonProperty]
		public string PrimaryContactPhone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>305cf861c8f553446031d22acc6d7f04</Hash>
</Codenesium>*/