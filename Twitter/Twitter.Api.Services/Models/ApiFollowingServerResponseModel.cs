using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiFollowingServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int userId,
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
		public int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>584c8632b52d25ef65a9fc57792effe0</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/