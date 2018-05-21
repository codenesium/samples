using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOEmployee
	{
		Task<CreateResponse<POCOEmployee>> Create(
			ApiEmployeeModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiEmployeeModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<POCOEmployee> Get(int businessEntityID);

		Task<List<POCOEmployee>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOEmployee> GetLoginID(string loginID);
		Task<POCOEmployee> GetNationalIDNumber(string nationalIDNumber);
		Task<List<POCOEmployee>> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel,Nullable<Guid> organizationNode);
		Task<List<POCOEmployee>> GetOrganizationNode(Nullable<Guid> organizationNode);
	}
}

/*<Codenesium>
    <Hash>f95f4777d6d23cd6bfd2e85cd59079f0</Hash>
</Codenesium>*/