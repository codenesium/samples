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
			BOPipelineStatus BOPipelineStatus = new BOPipelineStatus();

			BOPipelineStatus.SetProperties(
				id,
				model.Name);
			return BOPipelineStatus;
		}

		public virtual ApiPipelineStatusResponseModel MapBOToModel(
			BOPipelineStatus BOPipelineStatus)
		{
			if (BOPipelineStatus == null)
			{
				return null;
			}

			var model = new ApiPipelineStatusResponseModel();

			model.SetProperties(BOPipelineStatus.Id, BOPipelineStatus.Name);

			return model;
		}

		public virtual List<ApiPipelineStatusResponseModel> MapBOToModel(
			List<BOPipelineStatus> BOs)
		{
			List<ApiPipelineStatusResponseModel> response = new List<ApiPipelineStatusResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>953c70cbbe45c3e6f694cf0d51d83f25</Hash>
</Codenesium>*/