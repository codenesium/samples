using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NebulaNS.Api.Client
{
	public partial class ApiLinkLogClientResponseModel : AbstractApiClientResponseModel
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

			this.LinkIdEntity = nameof(ApiResponse.Links);
		}

		[JsonProperty]
		public ApiLinkClientResponseModel LinkIdNavigation { get; private set; }

		public void SetLinkIdNavigation(ApiLinkClientResponseModel value)
		{
			this.LinkIdNavigation = value;
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
    <Hash>b59249c33927b0bcea6fd4f804e0b976</Hash>
</Codenesium>*/