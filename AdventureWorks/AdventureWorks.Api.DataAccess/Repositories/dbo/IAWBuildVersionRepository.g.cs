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

		Task<List<AWBuildVersion>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>6d715b37553c0306337ea751fbc13f92</Hash>
</Codenesium>*/