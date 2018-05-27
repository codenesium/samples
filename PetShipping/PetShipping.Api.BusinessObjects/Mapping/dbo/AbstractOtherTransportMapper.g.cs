using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLOtherTransportMapper
	{
		public virtual DTOOtherTransport MapModelToDTO(
			int id,
			ApiOtherTransportRequestModel model
			)
		{
			DTOOtherTransport dtoOtherTransport = new DTOOtherTransport();

			dtoOtherTransport.SetProperties(
				id,
				model.HandlerId,
				model.PipelineStepId);
			return dtoOtherTransport;
		}

		public virtual ApiOtherTransportResponseModel MapDTOToModel(
			DTOOtherTransport dtoOtherTransport)
		{
			if (dtoOtherTransport == null)
			{
				return null;
			}

			var model = new ApiOtherTransportResponseModel();

			model.SetProperties(dtoOtherTransport.HandlerId, dtoOtherTransport.Id, dtoOtherTransport.PipelineStepId);

			return model;
		}

		public virtual List<ApiOtherTransportResponseModel> MapDTOToModel(
			List<DTOOtherTransport> dtos)
		{
			List<ApiOtherTransportResponseModel> response = new List<ApiOtherTransportResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b372c91cf54b0bc3e175de6c64edeb09</Hash>
</Codenesium>*/