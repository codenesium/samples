using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractChainStatusMapper
	{
		public virtual BOChainStatus MapModelToBO(
			int id,
			ApiChainStatusServerRequestModel model
			)
		{
			BOChainStatus boChainStatus = new BOChainStatus();
			boChainStatus.SetProperties(
				id,
				model.Name);
			return boChainStatus;
		}

		public virtual ApiChainStatusServerResponseModel MapBOToModel(
			BOChainStatus boChainStatus)
		{
			var model = new ApiChainStatusServerResponseModel();

			model.SetProperties(boChainStatus.Id, boChainStatus.Name);

			return model;
		}

		public virtual List<ApiChainStatusServerResponseModel> MapBOToModel(
			List<BOChainStatus> items)
		{
			List<ApiChainStatusServerResponseModel> response = new List<ApiChainStatusServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bead37be05f8c4456485712ceccf2604</Hash>
</Codenesium>*/