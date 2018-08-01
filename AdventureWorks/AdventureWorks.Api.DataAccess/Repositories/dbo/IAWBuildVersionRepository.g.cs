using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAWBuildVersionRepository
	{
		Task<AWBuildVersion> Create(AWBuildVersion item);

		Task Update(AWBuildVersion item);

		Task Delete(int systemInformationID);

		Task<AWBuildVersion> Get(int systemInformationID);

		Task<List<AWBuildVersion>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f3c4c96c60ad3679890e164be1a93519</Hash>
</Codenesium>*/