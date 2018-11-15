using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace TestsNS.Api.Services
{
	public partial class ApiSelfReferenceServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiSelfReferenceServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int? selfReferenceId,
			int? selfReferenceId2)
		{
			this.SelfReferenceId = selfReferenceId;
			this.SelfReferenceId2 = selfReferenceId2;
		}

		[JsonProperty]
		public int? SelfReferenceId { get; private set; } = default(int);

		[JsonProperty]
		public int? SelfReferenceId2 { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>9e9b1ae74d2f26a4bc65d99132250e7d</Hash>
</Codenesium>*/