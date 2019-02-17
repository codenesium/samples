using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALPipelineMapper
	{
		public virtual Pipeline MapModelToEntity(
			int id,
			ApiPipelineServerRequestModel model
			)
		{
			Pipeline item = new Pipeline();
			item.SetProperties(
				id,
				model.PipelineStatusId,
				model.SaleId);
			return item;
		}

		public virtual ApiPipelineServerResponseModel MapEntityToModel(
			Pipeline item)
		{
			var model = new ApiPipelineServerResponseModel();

			model.SetProperties(item.Id,
			                    item.PipelineStatusId,
			                    item.SaleId);
			if (item.PipelineStatusIdNavigation != null)
			{
				var pipelineStatusIdModel = new ApiPipelineStatuServerResponseModel();
				pipelineStatusIdModel.SetProperties(
					item.PipelineStatusIdNavigation.Id,
					item.PipelineStatusIdNavigation.Name);

				model.SetPipelineStatusIdNavigation(pipelineStatusIdModel);
			}

			return model;
		}

		public virtual List<ApiPipelineServerResponseModel> MapEntityToModel(
			List<Pipeline> items)
		{
			List<ApiPipelineServerResponseModel> response = new List<ApiPipelineServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5f7e45b12d1deaa1737a38601ef4f3e0</Hash>
</Codenesium>*/