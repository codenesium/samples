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

		POCOAWBuildVersion Get(int systemInformationID);

		List<POCOAWBuildVersion> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>087c591fca1defc603705bcfe4673cb7</Hash>
</Codenesium>*/