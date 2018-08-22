using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
	public partial class ApiFamilyRequestModel : AbstractApiRequestModel
	{
		public ApiFamilyRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string note,
			string pcEmail,
			string pcFirstName,
			string pcLastName,
			string pcPhone,
			int studioId)
		{
			this.Note = note;
			this.PcEmail = pcEmail;
			this.PcFirstName = pcFirstName;
			this.PcLastName = pcLastName;
			this.PcPhone = pcPhone;
			this.StudioId = studioId;
		}

		[Required]
		[JsonProperty]
		public string Note { get; private set; }

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
	}
}

/*<Codenesium>
    <Hash>e7743a1a0ea031e879b93c1869f1c771</Hash>
</Codenesium>*/