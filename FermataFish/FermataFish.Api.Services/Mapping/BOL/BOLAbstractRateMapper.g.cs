using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractRateMapper
	{
		public virtual BORate MapModelToBO(
			int id,
			ApiRateRequestModel model
			)
		{
			BORate BORate = new BORate();

			BORate.SetProperties(
				id,
				model.AmountPerMinute,
				model.TeacherId,
				model.TeacherSkillId);
			return BORate;
		}

		public virtual ApiRateResponseModel MapBOToModel(
			BORate BORate)
		{
			if (BORate == null)
			{
				return null;
			}

			var model = new ApiRateResponseModel();

			model.SetProperties(BORate.AmountPerMinute, BORate.Id, BORate.TeacherId, BORate.TeacherSkillId);

			return model;
		}

		public virtual List<ApiRateResponseModel> MapBOToModel(
			List<BORate> BOs)
		{
			List<ApiRateResponseModel> response = new List<ApiRateResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5dc370d623dc36a43466b80f68199cf7</Hash>
</Codenesium>*/