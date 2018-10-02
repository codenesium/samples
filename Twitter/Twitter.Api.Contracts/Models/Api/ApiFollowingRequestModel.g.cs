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
		public DateTime? DateFollowed { get; private set; }

		[JsonProperty]
		public string Muted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2ab27fbb42f1a60919bdb34b6d6a1d1c</Hash>
</Codenesium>*/