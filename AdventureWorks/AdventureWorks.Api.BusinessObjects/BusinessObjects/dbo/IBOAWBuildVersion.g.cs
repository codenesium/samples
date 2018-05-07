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
		Task<CreateResponse<int>> Create(
			AWBuildVersionModel model);

		Task<ActionResponse> Update(int systemInformationID,
		                            AWBuildVersionModel model);

		Task<ActionResponse> Delete(int systemInformationID);

		POCOAWBuildVersion Get(int systemInformationID);

		List<POCOAWBuildVersion> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e7215161a0065c2503a05e816b59ae46</Hash>
</Codenesium>*/