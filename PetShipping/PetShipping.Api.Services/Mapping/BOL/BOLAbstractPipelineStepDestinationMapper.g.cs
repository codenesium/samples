using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStepDestinationMapper
	{
		public virtual BOPipelineStepDestination MapModelToBO(
			int id,
			ApiPipelineStepDestinationServerRequestModel model
			)
		{
			BOPipelineStepDestination boPipelineStepDestination = new BOPipelineStepDestination();
			boPipelineStepDestination.SetProperties(
				id,
				model.DestinationId,
				model.PipelineStepId);
			return boPipelineStepDestination;
		}

		public virtual ApiPipelineStepDestinationServerResponseModel MapBOToModel(
			BOPipelineStepDestination boPipelineStepDestination)
		{
			var model = new ApiPipelineStepDestinationServerResponseModel();

			model.SetProperties(boPipelineStepDestination.Id, boPipelineStepDestination.DestinationId, boPipelineStepDestination.PipelineStepId);

			return model;
		}

		public virtual List<ApiPipelineStepDestinationServerResponseModel> MapBOToModel(
			List<BOPipelineStepDestination> items)
		{
			List<ApiPipelineStepDestinationServerResponseModel> response = new List<ApiPipelineStepDestinationServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>80affc6b15f5fa8c820e76f39b5ba854</Hash>
</Codenesium>*/