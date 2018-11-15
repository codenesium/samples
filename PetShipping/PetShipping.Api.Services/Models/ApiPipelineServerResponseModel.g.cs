using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiPipelineServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int id,
			int pipelineStatusId,
			int saleId)
		{
			this.Id = id;
			this.PipelineStatusId = pipelineStatusId;
			this.SaleId = saleId;
		}

		[JsonProperty]
		public int Id { get; private set; }

		[JsonProperty]
		public int PipelineStatusId { get; private set; }

		[JsonProperty]
		public string PipelineStatusIdEntity { get; set; }

		[JsonProperty]
		public int SaleId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2b57566193a0db9bf639b5c6abd69bf5</Hash>
</Codenesium>*/