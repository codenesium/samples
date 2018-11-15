using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractEventStatuMapper
	{
		public virtual BOEventStatu MapModelToBO(
			int id,
			ApiEventStatuServerRequestModel model
			)
		{
			BOEventStatu boEventStatu = new BOEventStatu();
			boEventStatu.SetProperties(
				id,
				model.Name);
			return boEventStatu;
		}

		public virtual ApiEventStatuServerResponseModel MapBOToModel(
			BOEventStatu boEventStatu)
		{
			var model = new ApiEventStatuServerResponseModel();

			model.SetProperties(boEventStatu.Id, boEventStatu.Name);

			return model;
		}

		public virtual List<ApiEventStatuServerResponseModel> MapBOToModel(
			List<BOEventStatu> items)
		{
			List<ApiEventStatuServerResponseModel> response = new List<ApiEventStatuServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>81557af58b5121fd8dd99d2933b181e3</Hash>
</Codenesium>*/