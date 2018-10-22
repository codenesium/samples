using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public DateTime DateEntered { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public int LinkId { get; private set; }

		[Required]
		[JsonProperty]
		public string Log { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>32179c38bf1ae8c7b972120b356e5b1d</Hash>
</Codenesium>*/