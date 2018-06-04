using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAWBuildVersionRepository
	{
		Task<AWBuildVersion> Create(AWBuildVersion item);

		Task Update(AWBuildVersion item);

		Task Delete(int systemInformationID);

		Task<AWBuildVersion> Get(int systemInformationID);

		Task<List<AWBuildVersion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>530f6b63c79d2782fdf11aeabc40e268</Hash>
</Codenesium>*/