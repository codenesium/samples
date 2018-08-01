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

		[JsonProperty]
		public DateTime DateEntered { get; private set; }

		[JsonProperty]
		public int LinkId { get; private set; }

		[JsonProperty]
		public string Log { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1da8333c09e825102a7d35ed0846eaa6</Hash>
</Codenesium>*/