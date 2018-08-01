using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiFamilyResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			int id,
			string notes,
			string pcEmail,
			string pcFirstName,
			string pcLastName,
			string pcPhone,
			int studioId)
		{
			this.Id = id;
			this.Notes = notes;
			this.PcEmail = pcEmail;
			this.PcFirstName = pcFirstName;
			this.PcLastName = pcLastName;
			this.PcPhone = pcPhone;
			this.StudioId = studioId;

			this.IdEntity = nameof(ApiResponse.Studios);
			this.StudioIdEntity = nameof(ApiResponse.Studios);
		}

		[Required]
		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string IdEntity { get; set; }

		[Required]
		[JsonProperty]
		public string Notes { get; private set; }

		[Required]
		[JsonProperty]
		public string PcEmail { get; private set; }

		[Required]
		[JsonProperty]
		public string PcFirstName { get; private set; }

		[Required]
		[JsonProperty]
		public string PcLastName { get; private set; }

		[Required]
		[JsonProperty]
		public string PcPhone { get; private set; }

		[Required]
		[JsonProperty]
		public int StudioId { get; private set; }

		[JsonProperty]
		public string StudioIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>d542026367f5bdddf48c5faf131536f1</Hash>
</Codenesium>*/