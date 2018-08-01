using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class DALAbstractEmployeeMapper
	{
		public virtual Employee MapBOToEF(
			BOEmployee bo)
		{
			Employee efEmployee = new Employee();
			efEmployee.SetProperties(
				bo.BirthDate,
				bo.BusinessEntityID,
				bo.CurrentFlag,
				bo.Gender,
				bo.HireDate,
				bo.JobTitle,
				bo.LoginID,
				bo.MaritalStatu,
				bo.ModifiedDate,
				bo.NationalIDNumber,
				bo.OrganizationLevel,
				bo.Rowguid,
				bo.SalariedFlag,
				bo.SickLeaveHour,
				bo.VacationHour);
			return efEmployee;
		}

		public virtual BOEmployee MapEFToBO(
			Employee ef)
		{
			var bo = new BOEmployee();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.BirthDate,
				ef.CurrentFlag,
				ef.Gender,
				ef.HireDate,
				ef.JobTitle,
				ef.LoginID,
				ef.MaritalStatu,
				ef.ModifiedDate,
				ef.NationalIDNumber,
				ef.OrganizationLevel,
				ef.Rowguid,
				ef.SalariedFlag,
				ef.SickLeaveHour,
				ef.VacationHour);
			return bo;
		}

		public virtual List<BOEmployee> MapEFToBO(
			List<Employee> records)
		{
			List<BOEmployee> response = new List<BOEmployee>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e765ab4938b9b4718580598a66e1c820</Hash>
</Codenesium>*/