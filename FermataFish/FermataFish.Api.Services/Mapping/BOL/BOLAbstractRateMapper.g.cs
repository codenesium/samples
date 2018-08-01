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
				model.TeacherSkillId);
			return boRate;
		}

		public virtual ApiRateResponseModel MapBOToModel(
			BORate boRate)
		{
			var model = new ApiRateResponseModel();

			model.SetProperties(boRate.Id, boRate.AmountPerMinute, boRate.TeacherId, boRate.TeacherSkillId);

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
    <Hash>89feac2eaef7d7a907a5c7b1bbc2aaf0</Hash>
</Codenesium>*/