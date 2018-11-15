using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Client
{
	public partial class ApiFollowingClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiFollowingClientRequestModel()
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
    <Hash>d3e579489cccdda326b174224d5bd11e</Hash>
</Codenesium>*/