using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
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
		public DateTime? DateFollowed { get; private set; } = null;

		[JsonProperty]
		public string Muted { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>9353a676e43b26e7e15dd260d7b7311f</Hash>
</Codenesium>*/