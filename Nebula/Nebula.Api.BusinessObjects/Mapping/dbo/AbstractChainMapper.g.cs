using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOLChainMapper
	{
		public virtual DTOChain MapModelToDTO(
			int id,
			ApiChainRequestModel model
			)
		{
			DTOChain dtoChain = new DTOChain();

			dtoChain.SetProperties(
				id,
				model.ChainStatusId,
				model.ExternalId,
				model.Name,
				model.TeamId);
			return dtoChain;
		}

		public virtual ApiChainResponseModel MapDTOToModel(
			DTOChain dtoChain)
		{
			if (dtoChain == null)
			{
				return null;
			}

			var model = new ApiChainResponseModel();

			model.SetProperties(dtoChain.ChainStatusId, dtoChain.ExternalId, dtoChain.Id, dtoChain.Name, dtoChain.TeamId);

			return model;
		}

		public virtual List<ApiChainResponseModel> MapDTOToModel(
			List<DTOChain> dtos)
		{
			List<ApiChainResponseModel> response = new List<ApiChainResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>95b027f4c3cbc82de6cd7a099cda2305</Hash>
</Codenesium>*/