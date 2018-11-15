using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiPipelineStepServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			string name,
			int pipelineStepStatusId,
			int shipperId)
		{
			this.Id = id;
			this.Name = name;
			this.PipelineStepStatusId = pipelineStepStatusId;
			this.ShipperId = shipperId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public int PipelineStepStatusId { get; private set; }

		[JsonProperty]
		public string PipelineStepStatusIdEntity { get; set; }

		[JsonProperty]
		public int ShipperId { get; private set; }

		[JsonProperty]
		public string ShipperIdEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>4a28dfb782616d2eb6963cabe1357243</Hash>
</Codenesium>*/