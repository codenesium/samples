using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALEmployeeDepartmentHistoryMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOEmployeeDepartmentHistory dto,
			EmployeeDepartmentHistory efEmployeeDepartmentHistory)
		{
			efEmployeeDepartmentHistory.SetProperties(
				businessEntityID,
				dto.DepartmentID,
				dto.EndDate,
				dto.ModifiedDate,
				dto.ShiftID,
				dto.StartDate);
		}

		public virtual DTOEmployeeDepartmentHistory MapEFToDTO(
			EmployeeDepartmentHistory ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOEmployeeDepartmentHistory();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.DepartmentID,
				ef.EndDate,
				ef.ModifiedDate,
				ef.ShiftID,
				ef.StartDate);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>e7a3dcbe7428208fca92b24ec395449b</Hash>
</Codenesium>*/