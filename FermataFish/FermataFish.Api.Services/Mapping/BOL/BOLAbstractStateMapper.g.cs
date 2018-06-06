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
    <Hash>808b6f1fe78c54cb48f93f11418b438e</Hash>
</Codenesium>*/