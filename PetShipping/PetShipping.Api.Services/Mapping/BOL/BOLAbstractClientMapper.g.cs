using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractClientMapper
	{
		public virtual BOClient MapModelToBO(
			int id,
			ApiClientRequestModel model
			)
		{
			BOClient boClient = new BOClient();

			boClient.SetProperties(
				id,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Notes,
				model.Phone);
			return boClient;
		}

		public virtual ApiClientResponseModel MapBOToModel(
			BOClient boClient)
		{
			var model = new ApiClientResponseModel();

			model.SetProperties(boClient.Email, boClient.FirstName, boClient.Id, boClient.LastName, boClient.Notes, boClient.Phone);

			return model;
		}

		public virtual List<ApiClientResponseModel> MapBOToModel(
			List<BOClient> items)
		{
			List<ApiClientResponseModel> response = new List<ApiClientResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4358ea3cd41074449bff9b551b09e768</Hash>
</Codenesium>*/