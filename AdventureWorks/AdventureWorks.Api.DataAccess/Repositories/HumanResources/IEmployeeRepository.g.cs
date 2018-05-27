using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeeRepository
	{
		Task<DTOEmployee> Create(DTOEmployee dto);

		Task Update(int businessEntityID,
		            DTOEmployee dto);

		Task Delete(int businessEntityID);

		Task<DTOEmployee> Get(int businessEntityID);

		Task<List<DTOEmployee>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOEmployee> GetLoginID(string loginID);
		Task<DTOEmployee> GetNationalIDNumber(string nationalIDNumber);
		Task<List<DTOEmployee>> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel,Nullable<Guid> organizationNode);
		Task<List<DTOEmployee>> GetOrganizationNode(Nullable<Guid> organizationNode);
	}
}

/*<Codenesium>
    <Hash>0767d6029550bac10bd1ff56c20c0a68</Hash>
</Codenesium>*/