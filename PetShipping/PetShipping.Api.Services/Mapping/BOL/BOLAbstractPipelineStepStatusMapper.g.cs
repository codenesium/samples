using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStepStatusMapper
	{
		public virtual BOPipelineStepStatus MapModelToBO(
			int id,
			ApiPipelineStepStatusRequestModel model
			)
		{
			BOPipelineStepStatus BOPipelineStepStatus = new BOPipelineStepStatus();

			BOPipelineStepStatus.SetProperties(
				id,
				model.Name);
			return BOPipelineStepStatus;
		}

		public virtual ApiPipelineStepStatusResponseModel MapBOToModel(
			BOPipelineStepStatus BOPipelineStepStatus)
		{
			if (BOPipelineStepStatus == null)
			{
				return null;
			}

			var model = new ApiPipelineStepStatusResponseModel();

			model.SetProperties(BOPipelineStepStatus.Id, BOPipelineStepStatus.Name);

			return model;
		}

		public virtual List<ApiPipelineStepStatusResponseModel> MapBOToModel(
			List<BOPipelineStepStatus> BOs)
		{
			List<ApiPipelineStepStatusResponseModel> response = new List<ApiPipelineStepStatusResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4a41065f7984a2538dd47beb29523881</Hash>
</Codenesium>*/