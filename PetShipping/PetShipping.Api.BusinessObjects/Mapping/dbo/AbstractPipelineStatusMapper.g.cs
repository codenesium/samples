using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPipelineStatusMapper
	{
		public virtual DTOPipelineStatus MapModelToDTO(
			int id,
			ApiPipelineStatusRequestModel model
			)
		{
			DTOPipelineStatus dtoPipelineStatus = new DTOPipelineStatus();

			dtoPipelineStatus.SetProperties(
				id,
				model.Name);
			return dtoPipelineStatus;
		}

		public virtual ApiPipelineStatusResponseModel MapDTOToModel(
			DTOPipelineStatus dtoPipelineStatus)
		{
			if (dtoPipelineStatus == null)
			{
				return null;
			}

			var model = new ApiPipelineStatusResponseModel();

			model.SetProperties(dtoPipelineStatus.Id, dtoPipelineStatus.Name);

			return model;
		}

		public virtual List<ApiPipelineStatusResponseModel> MapDTOToModel(
			List<DTOPipelineStatus> dtos)
		{
			List<ApiPipelineStatusResponseModel> response = new List<ApiPipelineStatusResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7f75ad697e729e060919d3d621932779</Hash>
</Codenesium>*/