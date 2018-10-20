using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TwitterNS.Api.Contracts
{
	public partial class ApiFollowingRequestModel : AbstractApiRequestModel
	{
		public ApiFollowingRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime? dateFollowed,
			string muted)
		{
			this.DateFollowed = dateFollowed;
			this.Muted = muted;
		}

		[JsonProperty]
		public DateTime? DateFollowed { get; private set; } = default(DateTime);

		[JsonProperty]
		public string Muted { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>3243721ded2e194d49868bf397f47527</Hash>
</Codenesium>*/