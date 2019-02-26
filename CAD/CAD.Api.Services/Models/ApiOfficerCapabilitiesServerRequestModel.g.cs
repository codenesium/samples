using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiOfficerCapabilitiesServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiOfficerCapabilitiesServerRequestModel()
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
    <Hash>98d43aca84ca5f9d863162b85fe59caa</Hash>
</Codenesium>*/