using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALEmployeeMapper
	{
		public virtual Employee MapBOToEF(
			BOEmployee bo)
		{
			Employee efEmployee = new Employee ();

			efEmployee.SetProperties(
				bo.BirthDate,
				bo.BusinessEntityID,
				bo.CurrentFlag,
				bo.Gender,
				bo.HireDate,
				bo.JobTitle,
				bo.LoginID,
				bo.MaritalStatus,
				bo.ModifiedDate,
				bo.NationalIDNumber,
				bo.OrganizationLevel,
				bo.OrganizationNode,
				bo.Rowguid,
				bo.SalariedFlag,
				bo.SickLeaveHours,
				bo.VacationHours);
			return efEmployee;
		}

		public virtual BOEmployee MapEFToBO(
			Employee ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOEmployee();

			bo.SetProperties(
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
    <Hash>3cd34fd70f021de572a0803fc0fa78f2</Hash>
</Codenesium>*/