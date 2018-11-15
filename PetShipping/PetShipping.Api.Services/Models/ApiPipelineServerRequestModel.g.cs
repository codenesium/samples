using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
	public partial class ApiPipelineServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiPipelineServerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int pipelineStatusId,
			int saleId)
		{
			this.PipelineStatusId = pipelineStatusId;
			this.SaleId = saleId;
		}

		[Required]
		[JsonProperty]
		public int PipelineStatusId { get; private set; }

		[Required]
		[JsonProperty]
		public int SaleId { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>ad54b8e577e9366361fe6465eee4b2b8</Hash>
</Codenesium>*/