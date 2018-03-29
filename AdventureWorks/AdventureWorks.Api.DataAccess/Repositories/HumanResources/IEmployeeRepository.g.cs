using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeeRepository
	{
		int Create(string nationalIDNumber,
		           string loginID,
		           Nullable<Guid> organizationNode,
		           Nullable<short> organizationLevel,
		           string jobTitle,
		           DateTime birthDate,
		           string maritalStatus,
		           string gender,
		           DateTime hireDate,
		           bool salariedFlag,
		           short vacationHours,
		           short sickLeaveHours,
		           bool currentFlag,
		           Guid rowguid,
		           DateTime modifiedDate);

		void Update(int businessEntityID, string nationalIDNumber,
		            string loginID,
		            Nullable<Guid> organizationNode,
		            Nullable<short> organizationLevel,
		            string jobTitle,
		            DateTime birthDate,
		            string maritalStatus,
		            string gender,
		            DateTime hireDate,
		            bool salariedFlag,
		            short vacationHours,
		            short sickLeaveHours,
		            bool currentFlag,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		void GetById(int businessEntityID, Response response);

		void GetWhere(Expression<Func<EFEmployee, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d28c6dc3b9f84767d1ea363f26f2c774</Hash>
</Codenesium>*/