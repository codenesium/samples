using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPipelineMapper
	{
		public virtual DTOPipeline MapModelToDTO(
			int id,
			ApiPipelineRequestModel model
			)
		{
			DTOPipeline dtoPipeline = new DTOPipeline();

			dtoPipeline.SetProperties(
				id,
				model.PipelineStatusId,
				model.SaleId);
			return dtoPipeline;
		}

		public virtual ApiPipelineResponseModel MapDTOToModel(
			DTOPipeline dtoPipeline)
		{
			if (dtoPipeline == null)
			{
				return null;
			}

			var model = new ApiPipelineResponseModel();

			model.SetProperties(dtoPipeline.Id, dtoPipeline.PipelineStatusId, dtoPipeline.SaleId);

			return model;
		}

		public virtual List<ApiPipelineResponseModel> MapDTOToModel(
			List<DTOPipeline> dtos)
		{
			List<ApiPipelineResponseModel> response = new List<ApiPipelineResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4129a1e9193d2d6aa03556e4897ad7ff</Hash>
</Codenesium>*/