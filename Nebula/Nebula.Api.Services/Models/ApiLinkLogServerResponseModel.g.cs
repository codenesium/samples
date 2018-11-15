using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
	public partial class ApiLinkLogServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			DateTime dateEntered,
			int linkId,
			string log)
		{
			this.Id = id;
			this.DateEntered = dateEntered;
			this.LinkId = linkId;
			this.Log = log;
		}

		[JsonProperty]
		public DateTime DateEntered { get; private set; }

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int LinkId { get; private set; }

		[JsonProperty]
		public string LinkIdEntity { get; set; }

		[JsonProperty]
		public string Log { get; private set; }
	}
}

/*<Codenesium>
    <Hash>570f5490cfaeb9616ea3b0a0fd6d39e8</Hash>
</Codenesium>*/