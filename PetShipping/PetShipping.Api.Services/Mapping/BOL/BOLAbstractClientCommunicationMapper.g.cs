using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractClientCommunicationMapper
	{
		public virtual BOClientCommunication MapModelToBO(
			int id,
			ApiClientCommunicationServerRequestModel model
			)
		{
			BOClientCommunication boClientCommunication = new BOClientCommunication();
			boClientCommunication.SetProperties(
				id,
				model.ClientId,
				model.DateCreated,
				model.EmployeeId,
				model.Note);
			return boClientCommunication;
		}

		public virtual ApiClientCommunicationServerResponseModel MapBOToModel(
			BOClientCommunication boClientCommunication)
		{
			var model = new ApiClientCommunicationServerResponseModel();

			model.SetProperties(boClientCommunication.Id, boClientCommunication.ClientId, boClientCommunication.DateCreated, boClientCommunication.EmployeeId, boClientCommunication.Note);

			return model;
		}

		public virtual List<ApiClientCommunicationServerResponseModel> MapBOToModel(
			List<BOClientCommunication> items)
		{
			List<ApiClientCommunicationServerResponseModel> response = new List<ApiClientCommunicationServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d59902abc11ee7c7212336a16c29942b</Hash>
</Codenesium>*/