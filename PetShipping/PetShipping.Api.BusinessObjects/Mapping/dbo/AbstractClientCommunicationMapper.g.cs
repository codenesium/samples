using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLClientCommunicationMapper
	{
		public virtual DTOClientCommunication MapModelToDTO(
			int id,
			ApiClientCommunicationRequestModel model
			)
		{
			DTOClientCommunication dtoClientCommunication = new DTOClientCommunication();

			dtoClientCommunication.SetProperties(
				id,
				model.ClientId,
				model.DateCreated,
				model.EmployeeId,
				model.Notes);
			return dtoClientCommunication;
		}

		public virtual ApiClientCommunicationResponseModel MapDTOToModel(
			DTOClientCommunication dtoClientCommunication)
		{
			if (dtoClientCommunication == null)
			{
				return null;
			}

			var model = new ApiClientCommunicationResponseModel();

			model.SetProperties(dtoClientCommunication.ClientId, dtoClientCommunication.DateCreated, dtoClientCommunication.EmployeeId, dtoClientCommunication.Id, dtoClientCommunication.Notes);

			return model;
		}

		public virtual List<ApiClientCommunicationResponseModel> MapDTOToModel(
			List<DTOClientCommunication> dtos)
		{
			List<ApiClientCommunicationResponseModel> response = new List<ApiClientCommunicationResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4cd0ce3559838acc2331cfbfc166dbf3</Hash>
</Codenesium>*/