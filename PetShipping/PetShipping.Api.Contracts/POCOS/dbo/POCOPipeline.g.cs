using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace PetShippingNS.Api.Contracts
{
	public partial class POCOPipeline
	{
		public POCOPipeline()
		{}

		public POCOPipeline(
			int id,
			int pipelineStatusId,
			int saleId)
		{
			this.Id = id.ToInt();
			this.SaleId = saleId.ToInt();

			this.PipelineStatusId = new ReferenceEntity<int>(pipelineStatusId,
			                                                 nameof(ApiResponse.PipelineStatus));
		}

		public int Id { get; set; }
		public ReferenceEntity<int> PipelineStatusId { get; set; }
		public int SaleId { get; set; }

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
    <Hash>e34caea050c0eb101336c37030ce4546</Hash>
</Codenesium>*/