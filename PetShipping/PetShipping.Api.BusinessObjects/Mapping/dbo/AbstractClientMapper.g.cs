using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOLClientMapper
	{
		public virtual DTOClient MapModelToDTO(
			int id,
			ApiClientRequestModel model
			)
		{
			DTOClient dtoClient = new DTOClient();

			dtoClient.SetProperties(
				id,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Notes,
				model.Phone);
			return dtoClient;
		}

		public virtual ApiClientResponseModel MapDTOToModel(
			DTOClient dtoClient)
		{
			if (dtoClient == null)
			{
				return null;
			}

			var model = new ApiClientResponseModel();

			model.SetProperties(dtoClient.Email, dtoClient.FirstName, dtoClient.Id, dtoClient.LastName, dtoClient.Notes, dtoClient.Phone);

			return model;
		}

		public virtual List<ApiClientResponseModel> MapDTOToModel(
			List<DTOClient> dtos)
		{
			List<ApiClientResponseModel> response = new List<ApiClientResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>027eca5f945d4b60e0f8ed5b3b8e6a6b</Hash>
</Codenesium>*/