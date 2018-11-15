using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractCustomerCommunicationMapper
	{
		public virtual BOCustomerCommunication MapModelToBO(
			int id,
			ApiCustomerCommunicationServerRequestModel model
			)
		{
			BOCustomerCommunication boCustomerCommunication = new BOCustomerCommunication();
			boCustomerCommunication.SetProperties(
				id,
				model.CustomerId,
				model.DateCreated,
				model.EmployeeId,
				model.Note);
			return boCustomerCommunication;
		}

		public virtual ApiCustomerCommunicationServerResponseModel MapBOToModel(
			BOCustomerCommunication boCustomerCommunication)
		{
			var model = new ApiCustomerCommunicationServerResponseModel();

			model.SetProperties(boCustomerCommunication.Id, boCustomerCommunication.CustomerId, boCustomerCommunication.DateCreated, boCustomerCommunication.EmployeeId, boCustomerCommunication.Note);

			return model;
		}

		public virtual List<ApiCustomerCommunicationServerResponseModel> MapBOToModel(
			List<BOCustomerCommunication> items)
		{
			List<ApiCustomerCommunicationServerResponseModel> response = new List<ApiCustomerCommunicationServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b2003672824c8b7d8d38104bd6ca0ac8</Hash>
</Codenesium>*/