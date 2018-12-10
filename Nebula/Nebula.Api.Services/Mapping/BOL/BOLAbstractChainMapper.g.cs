using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractChainMapper
	{
		public virtual BOChain MapModelToBO(
			int id,
			ApiChainServerRequestModel model
			)
		{
			BOChain boChain = new BOChain();
			boChain.SetProperties(
				id,
				model.ChainStatusId,
				model.ExternalId,
				model.Name,
				model.TeamId);
			return boChain;
		}

		public virtual ApiChainServerResponseModel MapBOToModel(
			BOChain boChain)
		{
			var model = new ApiChainServerResponseModel();

			model.SetProperties(boChain.Id, boChain.ChainStatusId, boChain.ExternalId, boChain.Name, boChain.TeamId);

			return model;
		}

		public virtual List<ApiChainServerResponseModel> MapBOToModel(
			List<BOChain> items)
		{
			List<ApiChainServerResponseModel> response = new List<ApiChainServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b862203ed11ae0cbcc6dcb2948fd3566</Hash>
</Codenesium>*/