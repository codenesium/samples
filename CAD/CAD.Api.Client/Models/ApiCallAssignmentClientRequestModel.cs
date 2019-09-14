using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace CADNS.Api.Client
{
	public partial class ApiCallAssignmentClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiCallAssignmentClientRequestModel()
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

		[JsonProperty]
		public int CallId { get; private set; }

		[JsonProperty]
		public int UnitId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9748ac00da9e3d32277e3caf51f420cb</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/