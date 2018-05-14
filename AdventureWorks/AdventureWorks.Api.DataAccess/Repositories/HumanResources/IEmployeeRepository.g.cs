using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeeRepository
	{
		POCOEmployee Create(ApiEmployeeModel model);

		void Update(int businessEntityID,
		            ApiEmployeeModel model);

		void Delete(int businessEntityID);

		POCOEmployee Get(int businessEntityID);

		List<POCOEmployee> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOEmployee GetLoginID(string loginID);

		POCOEmployee GetNationalIDNumber(string nationalIDNumber);

		List<POCOEmployee> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel,Nullable<Guid> organizationNode);
		List<POCOEmployee> GetOrganizationNode(Nullable<Guid> organizationNode);
	}
}

/*<Codenesium>
    <Hash>29d72501034345c6aae22b221cbd8a96</Hash>
</Codenesium>*/