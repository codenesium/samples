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
			string note,
			string pcEmail,
			string pcFirstName,
			string pcLastName,
			string pcPhone,
			int studioId)
		{
			this.Id = id;
			this.Note = note;
			this.PcEmail = pcEmail;
			this.PcFirstName = pcFirstName;
			this.PcLastName = pcLastName;
			this.PcPhone = pcPhone;
			this.StudioId = studioId;

			this.IdEntity = nameof(ApiResponse.Studios);
			this.StudioIdEntity = nameof(ApiResponse.Studios);
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string IdEntity { get; set; }

		[JsonProperty]
		public string Note { get; private set; }

		[JsonProperty]
		public string PcEmail { get; private set; }

		[JsonProperty]
		public string PcFirstName { get; private set; }

		[JsonProperty]
		public string PcLastName { get; private set; }

		[JsonProperty]
		public string PcPhone { get; private set; }

		[JsonProperty]
		public int StudioId { get; private set; }

		[JsonProperty]
		public string StudioIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>b2a2ed9e46ab0f6919010a20e4424743</Hash>
</Codenesium>*/