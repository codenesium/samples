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

		POCOEmployee Get(int businessEntityID);

		List<POCOEmployee> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOEmployee GetLoginID(string loginID);

		POCOEmployee GetNationalIDNumber(string nationalIDNumber);

		List<POCOEmployee> GetOrganizationLevelOrganizationNode(Nullable<short> organizationLevel,Nullable<Guid> organizationNode);
		List<POCOEmployee> GetOrganizationNode(Nullable<Guid> organizationNode);
	}
}

/*<Codenesium>
    <Hash>1e144ed989bc43a8010e42526ad0df5a</Hash>
</Codenesium>*/