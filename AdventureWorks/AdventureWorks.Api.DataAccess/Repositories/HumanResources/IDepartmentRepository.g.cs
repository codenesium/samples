using System;
using System.Linq.Expressions;
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

		void GetById(short departmentID, Response response);

		void GetWhere(Expression<Func<EFDepartment, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>abd430701d5d0a3a4e07398d6e6bb05f</Hash>
</Codenesium>*/