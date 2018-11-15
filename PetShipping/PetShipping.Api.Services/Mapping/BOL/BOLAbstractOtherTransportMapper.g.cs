using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractOtherTransportMapper
	{
		public virtual BOOtherTransport MapModelToBO(
			int id,
			ApiOtherTransportServerRequestModel model
			)
		{
			BOOtherTransport boOtherTransport = new BOOtherTransport();
			boOtherTransport.SetProperties(
				id,
				model.HandlerId,
				model.PipelineStepId);
			return boOtherTransport;
		}

		public virtual ApiOtherTransportServerResponseModel MapBOToModel(
			BOOtherTransport boOtherTransport)
		{
			var model = new ApiOtherTransportServerResponseModel();

			model.SetProperties(boOtherTransport.Id, boOtherTransport.HandlerId, boOtherTransport.PipelineStepId);

			return model;
		}

		public virtual List<ApiOtherTransportServerResponseModel> MapBOToModel(
			List<BOOtherTransport> items)
		{
			List<ApiOtherTransportServerResponseModel> response = new List<ApiOtherTransportServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>02c27049bc4006c0e66e089bb0a2292f</Hash>
</Codenesium>*/