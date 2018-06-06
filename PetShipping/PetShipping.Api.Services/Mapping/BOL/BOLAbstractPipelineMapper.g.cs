using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineMapper
	{
		public virtual BOPipeline MapModelToBO(
			int id,
			ApiPipelineRequestModel model
			)
		{
			BOPipeline boPipeline = new BOPipeline();

			boPipeline.SetProperties(
				id,
				model.PipelineStatusId,
				model.SaleId);
			return boPipeline;
		}

		public virtual ApiPipelineResponseModel MapBOToModel(
			BOPipeline boPipeline)
		{
			var model = new ApiPipelineResponseModel();

			model.SetProperties(boPipeline.Id, boPipeline.PipelineStatusId, boPipeline.SaleId);

			return model;
		}

		public virtual List<ApiPipelineResponseModel> MapBOToModel(
			List<BOPipeline> items)
		{
			List<ApiPipelineResponseModel> response = new List<ApiPipelineResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cce51920ce29425f2b1844a64696bde9</Hash>
</Codenesium>*/