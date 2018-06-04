using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALEmployeeDepartmentHistoryMapper
	{
		public virtual EmployeeDepartmentHistory MapBOToEF(
			BOEmployeeDepartmentHistory bo)
		{
			EmployeeDepartmentHistory efEmployeeDepartmentHistory = new EmployeeDepartmentHistory ();

			efEmployeeDepartmentHistory.SetProperties(
				bo.BusinessEntityID,
				bo.DepartmentID,
				bo.EndDate,
				bo.ModifiedDate,
				bo.ShiftID,
				bo.StartDate);
			return efEmployeeDepartmentHistory;
		}

		public virtual BOEmployeeDepartmentHistory MapEFToBO(
			EmployeeDepartmentHistory ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOEmployeeDepartmentHistory();

			bo.SetProperties(
				ef.BusinessEntityID,
				ef.DepartmentID,
				ef.EndDate,
				ef.ModifiedDate,
				ef.ShiftID,
				ef.StartDate);
			return bo;
		}

		public virtual List<BOEmployeeDepartmentHistory> MapEFToBO(
			List<EmployeeDepartmentHistory> records)
		{
			List<BOEmployeeDepartmentHistory> response = new List<BOEmployeeDepartmentHistory>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>aba6dad544a029e39e2b6609dd175608</Hash>
</Codenesium>*/