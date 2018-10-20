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
		public DateTime DateEntered { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int LinkId { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public string Log { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>af0f90212ca6f747f1790ded3efad5f3</Hash>
</Codenesium>*/