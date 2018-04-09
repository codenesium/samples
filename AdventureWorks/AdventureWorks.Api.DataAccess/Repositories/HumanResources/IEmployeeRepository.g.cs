using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int businessEntityID);

		POCOEmployee GetByIdDirect(int businessEntityID);

		Response GetWhere(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOEmployee> GetWhereDirect(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>79eee96d88c8a025ccca4c5c5957c401</Hash>
</Codenesium>*/