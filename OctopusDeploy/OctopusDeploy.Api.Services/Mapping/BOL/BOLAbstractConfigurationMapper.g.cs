using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractConfigurationMapper
	{
		public virtual BOConfiguration MapModelToBO(
			string id,
			ApiConfigurationRequestModel model
			)
		{
			BOConfiguration boConfiguration = new BOConfiguration();
			boConfiguration.SetProperties(
				id,
				model.JSON);
			return boConfiguration;
		}

		public virtual ApiConfigurationResponseModel MapBOToModel(
			BOConfiguration boConfiguration)
		{
			var model = new ApiConfigurationResponseModel();

			model.SetProperties(boConfiguration.Id, boConfiguration.JSON);

			return model;
		}

		public virtual List<ApiConfigurationResponseModel> MapBOToModel(
			List<BOConfiguration> items)
		{
			List<ApiConfigurationResponseModel> response = new List<ApiConfigurationResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a4ecc78a547cbc35af30ddf91cfbd70c</Hash>
</Codenesium>*/