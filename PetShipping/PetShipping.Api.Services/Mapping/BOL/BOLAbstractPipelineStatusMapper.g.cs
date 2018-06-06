using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class BOLAbstractPipelineStatusMapper
	{
		public virtual BOPipelineStatus MapModelToBO(
			int id,
			ApiPipelineStatusRequestModel model
			)
		{
			BOPipelineStatus boPipelineStatus = new BOPipelineStatus();

			boPipelineStatus.SetProperties(
				id,
				model.Name);
			return boPipelineStatus;
		}

		public virtual ApiPipelineStatusResponseModel MapBOToModel(
			BOPipelineStatus boPipelineStatus)
		{
			var model = new ApiPipelineStatusResponseModel();

			model.SetProperties(boPipelineStatus.Id, boPipelineStatus.Name);

			return model;
		}

		public virtual List<ApiPipelineStatusResponseModel> MapBOToModel(
			List<BOPipelineStatus> items)
		{
			List<ApiPipelineStatusResponseModel> response = new List<ApiPipelineStatusResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c005acf21ef3f5b6aaa04be62850804b</Hash>
</Codenesium>*/