using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiKeyAllocationRequestModel : AbstractApiRequestModel
	{
		public ApiKeyAllocationRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int allocated)
		{
			this.Allocated = allocated;
		}

		[JsonProperty]
		public int Allocated { get; private set; }
	}
}

/*<Codenesium>
    <Hash>c619f0a7995484155c46ac5cf1d0d7fc</Hash>
</Codenesium>*/