using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiPipelineResponseModel: AbstractApiResponseModel
	{
		public ApiPipelineResponseModel() : base()
		{}

		public void SetProperties(
			int id,
			int pipelineStatusId,
			int saleId)
		{
			this.Id = id.ToInt();
			this.PipelineStatusId = pipelineStatusId.ToInt();
			this.SaleId = saleId.ToInt();

			this.PipelineStatusIdEntity = nameof(ApiResponse.PipelineStatus);
		}

		public int Id { get; private set; }
		public int PipelineStatusId { get; private set; }
		public string PipelineStatusIdEntity { get; set; }
		public int SaleId { get; private set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializePipelineStatusIdValue { get; set; } = true;

		public bool ShouldSerializePipelineStatusId()
		{
			return this.ShouldSerializePipelineStatusIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSaleIdValue { get; set; } = true;

		public bool ShouldSerializeSaleId()
		{
			return this.ShouldSerializeSaleIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializePipelineStatusIdValue = false;
			this.ShouldSerializeSaleIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>158bde12116731a7b52b8bb845fc74c0</Hash>
</Codenesium>*/