using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractStateMapper
	{
		public virtual BOState MapModelToBO(
			int id,
			ApiStateRequestModel model
			)
		{
			BOState boState = new BOState();
			boState.SetProperties(
				id,
				model.Name);
			return boState;
		}

		public virtual ApiStateResponseModel MapBOToModel(
			BOState boState)
		{
			var model = new ApiStateResponseModel();

			model.SetProperties(boState.Id, boState.Name);

			return model;
		}

		public virtual List<ApiStateResponseModel> MapBOToModel(
			List<BOState> items)
		{
			List<ApiStateResponseModel> response = new List<ApiStateResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>04792747843c4b4761efdd5dcddc571b</Hash>
</Codenesium>*/