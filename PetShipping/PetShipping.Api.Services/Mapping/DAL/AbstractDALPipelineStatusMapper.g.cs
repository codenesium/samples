using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALPipelineStatusMapper
	{
		public virtual PipelineStatus MapModelToEntity(
			int id,
			ApiPipelineStatusServerRequestModel model
			)
		{
			PipelineStatus item = new PipelineStatus();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiPipelineStatusServerResponseModel MapEntityToModel(
			PipelineStatus item)
		{
			var model = new ApiPipelineStatusServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiPipelineStatusServerResponseModel> MapEntityToModel(
			List<PipelineStatus> items)
		{
			List<ApiPipelineStatusServerResponseModel> response = new List<ApiPipelineStatusServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>aa8e4e17e5d5c5f1807fb762510a7396</Hash>
</Codenesium>*/