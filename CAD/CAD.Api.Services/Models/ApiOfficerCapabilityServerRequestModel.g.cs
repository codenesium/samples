using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiOfficerCapabilityServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiOfficerCapabilityServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int officerId)
		{
			this.OfficerId = officerId;
		}

		[Required]
		[JsonProperty]
		public int OfficerId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6b0b4ca8dc71a5e9dba10f5457ffbe9a</Hash>
</Codenesium>*/