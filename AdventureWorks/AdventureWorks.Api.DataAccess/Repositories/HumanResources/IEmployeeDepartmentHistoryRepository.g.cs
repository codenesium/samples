using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeeDepartmentHistoryRepository
	{
		Task<DTOEmployeeDepartmentHistory> Create(DTOEmployeeDepartmentHistory dto);

		Task Update(int businessEntityID,
		            DTOEmployeeDepartmentHistory dto);

		Task Delete(int businessEntityID);

		Task<DTOEmployeeDepartmentHistory> Get(int businessEntityID);

		Task<List<DTOEmployeeDepartmentHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOEmployeeDepartmentHistory>> GetDepartmentID(short departmentID);
		Task<List<DTOEmployeeDepartmentHistory>> GetShiftID(int shiftID);
	}
}

/*<Codenesium>
    <Hash>a934495c12d26c125e812e17551fd902</Hash>
</Codenesium>*/