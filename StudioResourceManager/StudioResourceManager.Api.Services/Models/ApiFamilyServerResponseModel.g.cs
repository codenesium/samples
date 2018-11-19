using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class ApiFamilyServerResponseModel : AbstractApiServerResponseModel
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

		[Required]
		[JsonProperty]
		public string Note { get; private set; }

		[Required]
		[JsonProperty]
		public string PrimaryContactEmail { get; private set; }

		[Required]
		[JsonProperty]
		public string PrimaryContactFirstName { get; private set; }

		[Required]
		[JsonProperty]
		public string PrimaryContactLastName { get; private set; }

		[JsonProperty]
		public string PrimaryContactPhone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f426154e4b285ff756f8d77eae2aff71</Hash>
</Codenesium>*/