using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeeRepository
	{
		Task<POCOEmployee> Create(ApiEmployeeModel model);

		Task Update(int businessEntityID,
		            ApiEmployeeModel model);

		Task Delete(int businessEntityID);

		Task<POCOEmployee> Get(int businessEntityID);

		Task<List<POCOEmployee>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOEmployee> GetLoginID(string loginID);
		Task<POCOEmployee> GetNationalIDNumber(string nationalIDNumber);
		Task<List<POCOEmployee>> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel,Nullable<Guid> organizationNode);
		Task<List<POCOEmployee>> GetOrganizationNode(Nullable<Guid> organizationNode);
	}
}

/*<Codenesium>
    <Hash>5be13ea396c70fd211e0b01d28592edc</Hash>
</Codenesium>*/