using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAWBuildVersionRepository
	{
		Task<DTOAWBuildVersion> Create(DTOAWBuildVersion dto);

		Task Update(int systemInformationID,
		            DTOAWBuildVersion dto);

		Task Delete(int systemInformationID);

		Task<DTOAWBuildVersion> Get(int systemInformationID);

		Task<List<DTOAWBuildVersion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4a7f92394f4e3f1e0d9d89047d8d427f</Hash>
</Codenesium>*/