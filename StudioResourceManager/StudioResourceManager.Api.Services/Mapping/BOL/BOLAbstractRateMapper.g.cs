using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class BOLAbstractRateMapper
	{
		public virtual BORate MapModelToBO(
			int id,
			ApiRateServerRequestModel model
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

		public virtual ApiRateServerResponseModel MapBOToModel(
			BORate boRate)
		{
			var model = new ApiRateServerResponseModel();

			model.SetProperties(boRate.Id, boRate.AmountPerMinute, boRate.TeacherId, boRate.TeacherSkillId);

			return model;
		}

		public virtual List<ApiRateServerResponseModel> MapBOToModel(
			List<BORate> items)
		{
			List<ApiRateServerResponseModel> response = new List<ApiRateServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>21fe63e7077369cde27218fabe11909d</Hash>
</Codenesium>*/