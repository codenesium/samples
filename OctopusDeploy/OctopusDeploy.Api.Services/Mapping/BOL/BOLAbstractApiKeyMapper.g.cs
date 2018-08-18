using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractApiKeyMapper
	{
		public virtual BOApiKey MapModelToBO(
			string id,
			ApiApiKeyRequestModel model
			)
		{
			BOApiKey boApiKey = new BOApiKey();
			boApiKey.SetProperties(
				id,
				model.ApiKeyHashed,
				model.Created,
				model.JSON,
				model.UserId);
			return boApiKey;
		}

		public virtual ApiApiKeyResponseModel MapBOToModel(
			BOApiKey boApiKey)
		{
			var model = new ApiApiKeyResponseModel();

			model.SetProperties(boApiKey.Id, boApiKey.ApiKeyHashed, boApiKey.Created, boApiKey.JSON, boApiKey.UserId);

			return model;
		}

		public virtual List<ApiApiKeyResponseModel> MapBOToModel(
			List<BOApiKey> items)
		{
			List<ApiApiKeyResponseModel> response = new List<ApiApiKeyResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>31682929d0497760bf10cb13adf0fe40</Hash>
</Codenesium>*/