using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractChainStatusMapper
	{
		public virtual BOChainStatus MapModelToBO(
			int id,
			ApiChainStatusRequestModel model
			)
		{
			BOChainStatus boChainStatus = new BOChainStatus();
			boChainStatus.SetProperties(
				id,
				model.Name);
			return boChainStatus;
		}

		public virtual ApiChainStatusResponseModel MapBOToModel(
			BOChainStatus boChainStatus)
		{
			var model = new ApiChainStatusResponseModel();

			model.SetProperties(boChainStatus.Id, boChainStatus.Name);

			return model;
		}

		public virtual List<ApiChainStatusResponseModel> MapBOToModel(
			List<BOChainStatus> items)
		{
			List<ApiChainStatusResponseModel> response = new List<ApiChainStatusResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8879c823197a1e0b75ae4a99dd56089a</Hash>
</Codenesium>*/