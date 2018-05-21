using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOAWBuildVersion
	{
		Task<CreateResponse<POCOAWBuildVersion>> Create(
			ApiAWBuildVersionModel model);

		Task<ActionResponse> Update(int systemInformationID,
		                            ApiAWBuildVersionModel model);

		Task<ActionResponse> Delete(int systemInformationID);

		Task<POCOAWBuildVersion> Get(int systemInformationID);

		Task<List<POCOAWBuildVersion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f1304957a47465d26f8b090b974b4b65</Hash>
</Codenesium>*/