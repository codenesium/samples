using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOLClaspMapper
	{
		public virtual DTOClasp MapModelToDTO(
			int id,
			ApiClaspRequestModel model
			)
		{
			DTOClasp dtoClasp = new DTOClasp();

			dtoClasp.SetProperties(
				id,
				model.NextChainId,
				model.PreviousChainId);
			return dtoClasp;
		}

		public virtual ApiClaspResponseModel MapDTOToModel(
			DTOClasp dtoClasp)
		{
			if (dtoClasp == null)
			{
				return null;
			}

			var model = new ApiClaspResponseModel();

			model.SetProperties(dtoClasp.Id, dtoClasp.NextChainId, dtoClasp.PreviousChainId);

			return model;
		}

		public virtual List<ApiClaspResponseModel> MapDTOToModel(
			List<DTOClasp> dtos)
		{
			List<ApiClaspResponseModel> response = new List<ApiClaspResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>43a381859394326e93cdf7046fda0645</Hash>
</Codenesium>*/