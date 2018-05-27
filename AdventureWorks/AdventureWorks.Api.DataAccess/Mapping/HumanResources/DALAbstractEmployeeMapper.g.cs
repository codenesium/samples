using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALEmployeeMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOEmployee dto,
			Employee efEmployee)
		{
			efEmployee.SetProperties(
				businessEntityID,
				dto.BirthDate,
				dto.CurrentFlag,
				dto.Gender,
				dto.HireDate,
				dto.JobTitle,
				dto.LoginID,
				dto.MaritalStatus,
				dto.ModifiedDate,
				dto.NationalIDNumber,
				dto.OrganizationLevel,
				dto.OrganizationNode,
				dto.Rowguid,
				dto.SalariedFlag,
				dto.SickLeaveHours,
				dto.VacationHours);
		}

		public virtual DTOEmployee MapEFToDTO(
			Employee ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOEmployee();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.BirthDate,
				ef.CurrentFlag,
				ef.Gender,
				ef.HireDate,
				ef.JobTitle,
				ef.LoginID,
				ef.MaritalStatus,
				ef.ModifiedDate,
				ef.NationalIDNumber,
				ef.OrganizationLevel,
				ef.OrganizationNode,
				ef.Rowguid,
				ef.SalariedFlag,
				ef.SickLeaveHours,
				ef.VacationHours);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>a3464033588434b15f719398947bf9a8</Hash>
</Codenesium>*/