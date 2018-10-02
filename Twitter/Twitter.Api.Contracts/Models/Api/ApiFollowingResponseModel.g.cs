using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiFollowingResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string userId,
			DateTime? dateFollowed,
			string muted)
		{
			this.UserId = userId;
			this.DateFollowed = dateFollowed;
			this.Muted = muted;
		}

		[Required]
		[JsonProperty]
		public DateTime? DateFollowed { get; private set; }

		[Required]
		[JsonProperty]
		public string Muted { get; private set; }

		[JsonProperty]
		public string UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ccbef15714720b7e96627f9ba2562b81</Hash>
</Codenesium>*/