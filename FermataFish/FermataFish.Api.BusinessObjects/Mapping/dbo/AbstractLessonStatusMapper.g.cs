using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOLLessonStatusMapper
	{
		public virtual DTOLessonStatus MapModelToDTO(
			int id,
			ApiLessonStatusRequestModel model
			)
		{
			DTOLessonStatus dtoLessonStatus = new DTOLessonStatus();

			dtoLessonStatus.SetProperties(
				id,
				model.Name,
				model.StudioId);
			return dtoLessonStatus;
		}

		public virtual ApiLessonStatusResponseModel MapDTOToModel(
			DTOLessonStatus dtoLessonStatus)
		{
			if (dtoLessonStatus == null)
			{
				return null;
			}

			var model = new ApiLessonStatusResponseModel();

			model.SetProperties(dtoLessonStatus.Id, dtoLessonStatus.Name, dtoLessonStatus.StudioId);

			return model;
		}

		public virtual List<ApiLessonStatusResponseModel> MapDTOToModel(
			List<DTOLessonStatus> dtos)
		{
			List<ApiLessonStatusResponseModel> response = new List<ApiLessonStatusResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bcd7e74524a69a0ded2f234990b45d25</Hash>
</Codenesium>*/