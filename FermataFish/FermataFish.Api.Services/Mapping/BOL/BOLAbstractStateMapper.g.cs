using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractStateMapper
	{
		public virtual BOState MapModelToBO(
			int id,
			ApiStateRequestModel model
			)
		{
			BOState BOState = new BOState();

			BOState.SetProperties(
				id,
				model.Name);
			return BOState;
		}

		public virtual ApiStateResponseModel MapBOToModel(
			BOState BOState)
		{
			if (BOState == null)
			{
				return null;
			}

			var model = new ApiStateResponseModel();

			model.SetProperties(BOState.Id, BOState.Name);

			return model;
		}

		public virtual List<ApiStateResponseModel> MapBOToModel(
			List<BOState> BOs)
		{
			List<ApiStateResponseModel> response = new List<ApiStateResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ab3900855f785818fc5cdfba01047ef7</Hash>
</Codenesium>*/