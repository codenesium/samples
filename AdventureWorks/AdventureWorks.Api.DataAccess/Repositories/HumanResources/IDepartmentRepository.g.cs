using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDepartmentRepository
	{
		short Create(string name,
		             string groupName,
		             DateTime modifiedDate);

		void Update(short departmentID, string name,
		            string groupName,
		            DateTime modifiedDate);

		void Delete(short departmentID);

		Response GetById(short departmentID);

		POCODepartment GetByIdDirect(short departmentID);

		Response GetWhere(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCODepartment> GetWhereDirect(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bde75b966f7eb755046a706e78860af4</Hash>
</Codenesium>*/