using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractClientMapper
	{
		public virtual BOClient MapModelToBO(
			int id,
			ApiClientServerRequestModel model
			)
		{
			BOClient boClient = new BOClient();
			boClient.SetProperties(
				id,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Note,
				model.Phone);
			return boClient;
		}

		public virtual ApiClientServerResponseModel MapBOToModel(
			BOClient boClient)
		{
			var model = new ApiClientServerResponseModel();

			model.SetProperties(boClient.Id, boClient.Email, boClient.FirstName, boClient.LastName, boClient.Note, boClient.Phone);

			return model;
		}

		public virtual List<ApiClientServerResponseModel> MapBOToModel(
			List<BOClient> items)
		{
			List<ApiClientServerResponseModel> response = new List<ApiClientServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3e46bd5c63cbf108be48284373d49221</Hash>
</Codenesium>*/