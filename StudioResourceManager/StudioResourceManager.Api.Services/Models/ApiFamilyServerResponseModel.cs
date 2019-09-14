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
			string notes,
			string primaryContactEmail,
			string primaryContactFirstName,
			string primaryContactLastName,
			string primaryContactPhone)
		{
			this.Id = id;
			this.Notes = notes;
			this.PrimaryContactEmail = primaryContactEmail;
			this.PrimaryContactFirstName = primaryContactFirstName;
			this.PrimaryContactLastName = primaryContactLastName;
			this.PrimaryContactPhone = primaryContactPhone;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[Required]
		[JsonProperty]
		public string Notes { get; private set; }

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
    <Hash>2d22ec24c5818e0882e296ee1787733c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/