using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALLessonStatusMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOLessonStatus dto,
			LessonStatus efLessonStatus)
		{
			efLessonStatus.SetProperties(
				id,
				dto.Name,
				dto.StudioId);
		}

		public virtual DTOLessonStatus MapEFToDTO(
			LessonStatus ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOLessonStatus();

			dto.SetProperties(
				ef.Id,
				ef.Name,
				ef.StudioId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>34b6435e83356d70ef243945f13b66b9</Hash>
</Codenesium>*/