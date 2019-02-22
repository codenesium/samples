using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Services
{
	public partial class ApiCallAssignmentServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiCallAssignmentServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int callId,
			int unitId)
		{
			this.CallId = callId;
			this.UnitId = unitId;
		}

		[Required]
		[JsonProperty]
		public int CallId { get; private set; }

		[Required]
		[JsonProperty]
		public int UnitId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d6b4a6e10214c36960297b252c98c4a5</Hash>
</Codenesium>*/