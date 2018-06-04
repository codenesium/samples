using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStepDestinationMapper
	{
		public virtual BOPipelineStepDestination MapModelToBO(
			int id,
			ApiPipelineStepDestinationRequestModel model
			)
		{
			BOPipelineStepDestination BOPipelineStepDestination = new BOPipelineStepDestination();

			BOPipelineStepDestination.SetProperties(
				id,
				model.DestinationId,
				model.PipelineStepId);
			return BOPipelineStepDestination;
		}

		public virtual ApiPipelineStepDestinationResponseModel MapBOToModel(
			BOPipelineStepDestination BOPipelineStepDestination)
		{
			if (BOPipelineStepDestination == null)
			{
				return null;
			}

			var model = new ApiPipelineStepDestinationResponseModel();

			model.SetProperties(BOPipelineStepDestination.DestinationId, BOPipelineStepDestination.Id, BOPipelineStepDestination.PipelineStepId);

			return model;
		}

		public virtual List<ApiPipelineStepDestinationResponseModel> MapBOToModel(
			List<BOPipelineStepDestination> BOs)
		{
			List<ApiPipelineStepDestinationResponseModel> response = new List<ApiPipelineStepDestinationResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d4a68ed187a365fdadb37152f0acef2e</Hash>
</Codenesium>*/