using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractChainStatusMapper
	{
		public virtual BOChainStatus MapModelToBO(
			int id,
			ApiChainStatusRequestModel model
			)
		{
			BOChainStatus BOChainStatus = new BOChainStatus();

			BOChainStatus.SetProperties(
				id,
				model.Name);
			return BOChainStatus;
		}

		public virtual ApiChainStatusResponseModel MapBOToModel(
			BOChainStatus BOChainStatus)
		{
			if (BOChainStatus == null)
			{
				return null;
			}

			var model = new ApiChainStatusResponseModel();

			model.SetProperties(BOChainStatus.Id, BOChainStatus.Name);

			return model;
		}

		public virtual List<ApiChainStatusResponseModel> MapBOToModel(
			List<BOChainStatus> BOs)
		{
			List<ApiChainStatusResponseModel> response = new List<ApiChainStatusResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3d316214c7680b32f4f2f9edd8dd26a1</Hash>
</Codenesium>*/