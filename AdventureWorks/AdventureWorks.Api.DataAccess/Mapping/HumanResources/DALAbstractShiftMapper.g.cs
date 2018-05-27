using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALShiftMapper
	{
		public virtual void MapDTOToEF(
			int shiftID,
			DTOShift dto,
			Shift efShift)
		{
			efShift.SetProperties(
				shiftID,
				dto.EndTime,
				dto.ModifiedDate,
				dto.Name,
				dto.StartTime);
		}

		public virtual DTOShift MapEFToDTO(
			Shift ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOShift();

			dto.SetProperties(
				ef.ShiftID,
				ef.EndTime,
				ef.ModifiedDate,
				ef.Name,
				ef.StartTime);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>a2a70454ef2ca8d5b567d99bf0636882</Hash>
</Codenesium>*/