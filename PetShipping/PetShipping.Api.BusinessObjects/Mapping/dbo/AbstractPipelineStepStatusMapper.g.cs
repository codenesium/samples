using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLPipelineStepStatusMapper
	{
		public virtual DTOPipelineStepStatus MapModelToDTO(
			int id,
			ApiPipelineStepStatusRequestModel model
			)
		{
			DTOPipelineStepStatus dtoPipelineStepStatus = new DTOPipelineStepStatus();

			dtoPipelineStepStatus.SetProperties(
				id,
				model.Name);
			return dtoPipelineStepStatus;
		}

		public virtual ApiPipelineStepStatusResponseModel MapDTOToModel(
			DTOPipelineStepStatus dtoPipelineStepStatus)
		{
			if (dtoPipelineStepStatus == null)
			{
				return null;
			}

			var model = new ApiPipelineStepStatusResponseModel();

			model.SetProperties(dtoPipelineStepStatus.Id, dtoPipelineStepStatus.Name);

			return model;
		}

		public virtual List<ApiPipelineStepStatusResponseModel> MapDTOToModel(
			List<DTOPipelineStepStatus> dtos)
		{
			List<ApiPipelineStepStatusResponseModel> response = new List<ApiPipelineStepStatusResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5a8e08d897a26c38c076179873899c97</Hash>
</Codenesium>*/