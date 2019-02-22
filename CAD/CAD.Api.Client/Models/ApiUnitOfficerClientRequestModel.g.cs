using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiUnitOfficerClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiUnitOfficerClientRequestModel()
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

		[JsonProperty]
		public int OfficerId { get; private set; }

		[JsonProperty]
		public int UnitId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>61dfeaf0ec2fce65f2adec2d13256ee9</Hash>
</Codenesium>*/