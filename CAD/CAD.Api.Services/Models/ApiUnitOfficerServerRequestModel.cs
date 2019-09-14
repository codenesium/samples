using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiUnitOfficerServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiUnitOfficerServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int officerId,
			int unitId)
		{
			this.OfficerId = officerId;
			this.UnitId = unitId;
		}

		[Required]
		[JsonProperty]
		public int OfficerId { get; private set; }

		[Required]
		[JsonProperty]
		public int UnitId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4edc965e78a662951bda471bfe147ed6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/