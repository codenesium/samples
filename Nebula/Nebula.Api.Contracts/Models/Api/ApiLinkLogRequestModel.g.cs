using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Contracts
{
	public partial class ApiLinkLogRequestModel : AbstractApiRequestModel
	{
		public ApiLinkLogRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime dateEntered,
			int linkId,
			string log)
		{
			this.DateEntered = dateEntered;
			this.LinkId = linkId;
			this.Log = log;
		}

		[Required]
		[JsonProperty]
		public DateTime DateEntered { get; private set; }

		[Required]
		[JsonProperty]
		public int LinkId { get; private set; }

		[Required]
		[JsonProperty]
		public string Log { get; private set; }
	}
}

/*<Codenesium>
    <Hash>03a3c7fd42db5c0d59ac33914a170dae</Hash>
</Codenesium>*/