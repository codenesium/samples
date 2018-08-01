using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractClientCommunicationMapper
	{
		public virtual BOClientCommunication MapModelToBO(
			int id,
			ApiClientCommunicationRequestModel model
			)
		{
			BOClientCommunication boClientCommunication = new BOClientCommunication();
			boClientCommunication.SetProperties(
				id,
				model.ClientId,
				model.DateCreated,
				model.EmployeeId,
				model.Notes);
			return boClientCommunication;
		}

		public virtual ApiClientCommunicationResponseModel MapBOToModel(
			BOClientCommunication boClientCommunication)
		{
			var model = new ApiClientCommunicationResponseModel();

			model.SetProperties(boClientCommunication.Id, boClientCommunication.ClientId, boClientCommunication.DateCreated, boClientCommunication.EmployeeId, boClientCommunication.Notes);

			return model;
		}

		public virtual List<ApiClientCommunicationResponseModel> MapBOToModel(
			List<BOClientCommunication> items)
		{
			List<ApiClientCommunicationResponseModel> response = new List<ApiClientCommunicationResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>52fbfa69916dc5e39d07ba0ffd29dbdd</Hash>
</Codenesium>*/