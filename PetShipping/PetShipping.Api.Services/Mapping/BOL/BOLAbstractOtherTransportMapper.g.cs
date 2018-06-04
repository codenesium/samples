using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractOtherTransportMapper
	{
		public virtual BOOtherTransport MapModelToBO(
			int id,
			ApiOtherTransportRequestModel model
			)
		{
			BOOtherTransport BOOtherTransport = new BOOtherTransport();

			BOOtherTransport.SetProperties(
				id,
				model.HandlerId,
				model.PipelineStepId);
			return BOOtherTransport;
		}

		public virtual ApiOtherTransportResponseModel MapBOToModel(
			BOOtherTransport BOOtherTransport)
		{
			if (BOOtherTransport == null)
			{
				return null;
			}

			var model = new ApiOtherTransportResponseModel();

			model.SetProperties(BOOtherTransport.HandlerId, BOOtherTransport.Id, BOOtherTransport.PipelineStepId);

			return model;
		}

		public virtual List<ApiOtherTransportResponseModel> MapBOToModel(
			List<BOOtherTransport> BOs)
		{
			List<ApiOtherTransportResponseModel> response = new List<ApiOtherTransportResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fe8cc0e74d74d76eb75359d53951d9ea</Hash>
</Codenesium>*/