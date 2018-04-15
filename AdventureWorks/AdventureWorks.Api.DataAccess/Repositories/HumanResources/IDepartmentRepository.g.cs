using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDepartmentRepository
	{
		short Create(DepartmentModel model);

		void Update(short departmentID,
		            DepartmentModel model);

		void Delete(short departmentID);

		ApiResponse GetById(short departmentID);

		POCODepartment GetByIdDirect(short departmentID);

		ApiResponse GetWhere(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODepartment> GetWhereDirect(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>cf110f616b781632c56d350d633d04f1</Hash>
</Codenesium>*/