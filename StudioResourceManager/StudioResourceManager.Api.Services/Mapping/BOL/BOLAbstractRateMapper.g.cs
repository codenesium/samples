using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>a22fce65c73862a1ac7dd8f35ecfa029</Hash>
</Codenesium>*/