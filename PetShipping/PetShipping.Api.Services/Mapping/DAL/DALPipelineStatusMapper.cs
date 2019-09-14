using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public class DALPipelineStatusMapper : IDALPipelineStatusMapper
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
    <Hash>1eb2a788bfe6f192bc3a7b9f242947c8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/