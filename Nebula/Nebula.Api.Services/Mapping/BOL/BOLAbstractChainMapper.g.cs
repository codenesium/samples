using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractChainMapper
	{
		public virtual BOChain MapModelToBO(
			int id,
			ApiChainRequestModel model
			)
		{
			BOChain BOChain = new BOChain();

			BOChain.SetProperties(
				id,
				model.ChainStatusId,
				model.ExternalId,
				model.Name,
				model.TeamId);
			return BOChain;
		}

		public virtual ApiChainResponseModel MapBOToModel(
			BOChain BOChain)
		{
			if (BOChain == null)
			{
				return null;
			}

			var model = new ApiChainResponseModel();

			model.SetProperties(BOChain.ChainStatusId, BOChain.ExternalId, BOChain.Id, BOChain.Name, BOChain.TeamId);

			return model;
		}

		public virtual List<ApiChainResponseModel> MapBOToModel(
			List<BOChain> BOs)
		{
			List<ApiChainResponseModel> response = new List<ApiChainResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6810a54b5ddf64d46c4f33e9c6f3c02c</Hash>
</Codenesium>*/