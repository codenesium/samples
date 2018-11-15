using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineMapper
	{
		public virtual BOPipeline MapModelToBO(
			int id,
			ApiPipelineServerRequestModel model
			)
		{
			BOPipeline boPipeline = new BOPipeline();
			boPipeline.SetProperties(
				id,
				model.PipelineStatusId,
				model.SaleId);
			return boPipeline;
		}

		public virtual ApiPipelineServerResponseModel MapBOToModel(
			BOPipeline boPipeline)
		{
			var model = new ApiPipelineServerResponseModel();

			model.SetProperties(boPipeline.Id, boPipeline.PipelineStatusId, boPipeline.SaleId);

			return model;
		}

		public virtual List<ApiPipelineServerResponseModel> MapBOToModel(
			List<BOPipeline> items)
		{
			List<ApiPipelineServerResponseModel> response = new List<ApiPipelineServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>91e760abdc69c21c72804437d44350f9</Hash>
</Codenesium>*/