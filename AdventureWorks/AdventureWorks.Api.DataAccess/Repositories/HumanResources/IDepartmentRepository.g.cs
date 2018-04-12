using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDepartmentRepository
	{
		short Create(
			string name,
			string groupName,
			DateTime modifiedDate);

		void Update(short departmentID,
		            string name,
		            string groupName,
		            DateTime modifiedDate);

		void Delete(short departmentID);

		Response GetById(short departmentID);

		POCODepartment GetByIdDirect(short departmentID);

		Response GetWhere(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODepartment> GetWhereDirect(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7185dcfd25f8dfcb7643d0862508eb0a</Hash>
</Codenesium>*/