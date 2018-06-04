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
			BOPipeline BOPipeline = new BOPipeline();

			BOPipeline.SetProperties(
				id,
				model.PipelineStatusId,
				model.SaleId);
			return BOPipeline;
		}

		public virtual ApiPipelineResponseModel MapBOToModel(
			BOPipeline BOPipeline)
		{
			if (BOPipeline == null)
			{
				return null;
			}

			var model = new ApiPipelineResponseModel();

			model.SetProperties(BOPipeline.Id, BOPipeline.PipelineStatusId, BOPipeline.SaleId);

			return model;
		}

		public virtual List<ApiPipelineResponseModel> MapBOToModel(
			List<BOPipeline> BOs)
		{
			List<ApiPipelineResponseModel> response = new List<ApiPipelineResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5470d27eb3c44bb97865864f53518ee3</Hash>
</Codenesium>*/