using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public abstract class BOLAbstractLessonStatusMapper
	{
		public virtual BOLessonStatus MapModelToBO(
			int id,
			ApiLessonStatusRequestModel model
			)
		{
			BOLessonStatus BOLessonStatus = new BOLessonStatus();

			BOLessonStatus.SetProperties(
				id,
				model.Name,
				model.StudioId);
			return BOLessonStatus;
		}

		public virtual ApiLessonStatusResponseModel MapBOToModel(
			BOLessonStatus BOLessonStatus)
		{
			if (BOLessonStatus == null)
			{
				return null;
			}

			var model = new ApiLessonStatusResponseModel();

			model.SetProperties(BOLessonStatus.Id, BOLessonStatus.Name, BOLessonStatus.StudioId);

			return model;
		}

		public virtual List<ApiLessonStatusResponseModel> MapBOToModel(
			List<BOLessonStatus> BOs)
		{
			List<ApiLessonStatusResponseModel> response = new List<ApiLessonStatusResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1b7faa7481924d9f68cfea2110658878</Hash>
</Codenesium>*/