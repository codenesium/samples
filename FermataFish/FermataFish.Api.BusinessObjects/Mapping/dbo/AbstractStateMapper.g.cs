using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLStateMapper
	{
		public virtual DTOState MapModelToDTO(
			int id,
			ApiStateRequestModel model
			)
		{
			DTOState dtoState = new DTOState();

			dtoState.SetProperties(
				id,
				model.Name);
			return dtoState;
		}

		public virtual ApiStateResponseModel MapDTOToModel(
			DTOState dtoState)
		{
			if (dtoState == null)
			{
				return null;
			}

			var model = new ApiStateResponseModel();

			model.SetProperties(dtoState.Id, dtoState.Name);

			return model;
		}

		public virtual List<ApiStateResponseModel> MapDTOToModel(
			List<DTOState> dtos)
		{
			List<ApiStateResponseModel> response = new List<ApiStateResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2e2c500039644459569c68bacb979742</Hash>
</Codenesium>*/