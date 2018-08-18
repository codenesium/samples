using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class BOLAbstractChannelMapper
	{
		public virtual BOChannel MapModelToBO(
			string id,
			ApiChannelRequestModel model
			)
		{
			BOChannel boChannel = new BOChannel();
			boChannel.SetProperties(
				id,
				model.DataVersion,
				model.JSON,
				model.LifecycleId,
				model.Name,
				model.ProjectId,
				model.TenantTags);
			return boChannel;
		}

		public virtual ApiChannelResponseModel MapBOToModel(
			BOChannel boChannel)
		{
			var model = new ApiChannelResponseModel();

			model.SetProperties(boChannel.Id, boChannel.DataVersion, boChannel.JSON, boChannel.LifecycleId, boChannel.Name, boChannel.ProjectId, boChannel.TenantTags);

			return model;
		}

		public virtual List<ApiChannelResponseModel> MapBOToModel(
			List<BOChannel> items)
		{
			List<ApiChannelResponseModel> response = new List<ApiChannelResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e6ad7f95c7ca41ae693162e386af4c0b</Hash>
</Codenesium>*/