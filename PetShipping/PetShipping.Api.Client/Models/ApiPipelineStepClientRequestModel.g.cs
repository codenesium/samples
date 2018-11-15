using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Client
{
	public partial class ApiPipelineStepClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiPipelineStepClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string name,
			int pipelineStepStatusId,
			int shipperId)
		{
			this.Name = name;
			this.PipelineStepStatusId = pipelineStepStatusId;
			this.ShipperId = shipperId;
		}

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public int PipelineStepStatusId { get; private set; }

		[JsonProperty]
		public int ShipperId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1a779c843e6c57a748eb07e1954e8629</Hash>
</Codenesium>*/