using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractClientCommunicationMapper
	{
		public virtual BOClientCommunication MapModelToBO(
			int id,
			ApiClientCommunicationRequestModel model
			)
		{
			BOClientCommunication BOClientCommunication = new BOClientCommunication();

			BOClientCommunication.SetProperties(
				id,
				model.ClientId,
				model.DateCreated,
				model.EmployeeId,
				model.Notes);
			return BOClientCommunication;
		}

		public virtual ApiClientCommunicationResponseModel MapBOToModel(
			BOClientCommunication BOClientCommunication)
		{
			if (BOClientCommunication == null)
			{
				return null;
			}

			var model = new ApiClientCommunicationResponseModel();

			model.SetProperties(BOClientCommunication.ClientId, BOClientCommunication.DateCreated, BOClientCommunication.EmployeeId, BOClientCommunication.Id, BOClientCommunication.Notes);

			return model;
		}

		public virtual List<ApiClientCommunicationResponseModel> MapBOToModel(
			List<BOClientCommunication> BOs)
		{
			List<ApiClientCommunicationResponseModel> response = new List<ApiClientCommunicationResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3ac3a37538aaad7ae9d33cb55870d4ca</Hash>
</Codenesium>*/