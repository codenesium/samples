using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StudioResourceManagerNS.Api.Contracts
{
	public partial class ApiFamilyResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string note,
			string primaryContactEmail,
			string primaryContactFirstName,
			string primaryContactLastName,
			string primaryContactPhone,
			bool isDeleted)
		{
			this.Id = id;
			this.Note = note;
			this.PrimaryContactEmail = primaryContactEmail;
			this.PrimaryContactFirstName = primaryContactFirstName;
			this.PrimaryContactLastName = primaryContactLastName;
			this.PrimaryContactPhone = primaryContactPhone;
			this.IsDeleted = isDeleted;
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

		[JsonProperty]
		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>730cd614880e7f06f359cd72afcd7a4d</Hash>
</Codenesium>*/