using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractRateMapper
	{
		public virtual BORate MapModelToBO(
			int id,
			ApiRateRequestModel model
			)
		{
			BORate boRate = new BORate();
			boRate.SetProperties(
				id,
				model.AmountPerMinute,
				model.TeacherId,
				model.TeacherSkillId,
				model.StudioId);
			return boRate;
		}

		public virtual ApiRateResponseModel MapBOToModel(
			BORate boRate)
		{
			var model = new ApiRateResponseModel();

			model.SetProperties(boRate.Id, boRate.AmountPerMinute, boRate.TeacherId, boRate.TeacherSkillId, boRate.StudioId);

			return model;
		}

		public virtual List<ApiRateResponseModel> MapBOToModel(
			List<BORate> items)
		{
			List<ApiRateResponseModel> response = new List<ApiRateResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e96f53d00687a2d4b5dd341324086c38</Hash>
</Codenesium>*/