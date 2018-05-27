using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALStudentMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOStudent dto,
			Student efStudent)
		{
			efStudent.SetProperties(
				id,
				dto.Birthday,
				dto.Email,
				dto.EmailRemindersEnabled,
				dto.FamilyId,
				dto.FirstName,
				dto.IsAdult,
				dto.LastName,
				dto.Phone,
				dto.SmsRemindersEnabled,
				dto.StudioId);
		}

		public virtual DTOStudent MapEFToDTO(
			Student ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOStudent();

			dto.SetProperties(
				ef.Id,
				ef.Birthday,
				ef.Email,
				ef.EmailRemindersEnabled,
				ef.FamilyId,
				ef.FirstName,
				ef.IsAdult,
				ef.LastName,
				ef.Phone,
				ef.SmsRemindersEnabled,
				ef.StudioId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>aa081d105c495ced8d64296122843d66</Hash>
</Codenesium>*/