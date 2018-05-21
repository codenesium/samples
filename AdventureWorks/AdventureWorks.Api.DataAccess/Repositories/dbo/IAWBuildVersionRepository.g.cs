using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAWBuildVersionRepository
	{
		Task<POCOAWBuildVersion> Create(ApiAWBuildVersionModel model);

		Task Update(int systemInformationID,
		            ApiAWBuildVersionModel model);

		Task Delete(int systemInformationID);

		Task<POCOAWBuildVersion> Get(int systemInformationID);

		Task<List<POCOAWBuildVersion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8aee1ac74c8cca0a308eea95b5962372</Hash>
</Codenesium>*/