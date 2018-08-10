using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IAWBuildVersionRepository
	{
		Task<AWBuildVersion> Create(AWBuildVersion item);

		Task Update(AWBuildVersion item);

		Task Delete(int systemInformationID);

		Task<AWBuildVersion> Get(int systemInformationID);

		Task<List<AWBuildVersion>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>28e7d2eee36191e28c7f3d8c057478a4</Hash>
</Codenesium>*/