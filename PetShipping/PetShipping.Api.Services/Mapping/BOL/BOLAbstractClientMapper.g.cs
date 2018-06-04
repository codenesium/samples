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
			BOClient BOClient = new BOClient();

			BOClient.SetProperties(
				id,
				model.Email,
				model.FirstName,
				model.LastName,
				model.Notes,
				model.Phone);
			return BOClient;
		}

		public virtual ApiClientResponseModel MapBOToModel(
			BOClient BOClient)
		{
			if (BOClient == null)
			{
				return null;
			}

			var model = new ApiClientResponseModel();

			model.SetProperties(BOClient.Email, BOClient.FirstName, BOClient.Id, BOClient.LastName, BOClient.Notes, BOClient.Phone);

			return model;
		}

		public virtual List<ApiClientResponseModel> MapBOToModel(
			List<BOClient> BOs)
		{
			List<ApiClientResponseModel> response = new List<ApiClientResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>02bbb13cb234a28bd9aaecb8dd4843de</Hash>
</Codenesium>*/