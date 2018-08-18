using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractOtherTransportMapper
	{
		public virtual BOOtherTransport MapModelToBO(
			int id,
			ApiOtherTransportRequestModel model
			)
		{
			BOOtherTransport boOtherTransport = new BOOtherTransport();
			boOtherTransport.SetProperties(
				id,
				model.HandlerId,
				model.PipelineStepId);
			return boOtherTransport;
		}

		public virtual ApiOtherTransportResponseModel MapBOToModel(
			BOOtherTransport boOtherTransport)
		{
			var model = new ApiOtherTransportResponseModel();

			model.SetProperties(boOtherTransport.Id, boOtherTransport.HandlerId, boOtherTransport.PipelineStepId);

			return model;
		}

		public virtual List<ApiOtherTransportResponseModel> MapBOToModel(
			List<BOOtherTransport> items)
		{
			List<ApiOtherTransportResponseModel> response = new List<ApiOtherTransportResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2d056b12f1aeccd005c8954fb7865c57</Hash>
</Codenesium>*/