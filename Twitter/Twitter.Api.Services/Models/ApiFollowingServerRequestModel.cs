using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TwitterNS.Api.Services
{
	public partial class ApiFollowingServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiFollowingServerRequestModel()
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
    <Hash>b22c967024666826b0c65e3ee8c5fec7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/