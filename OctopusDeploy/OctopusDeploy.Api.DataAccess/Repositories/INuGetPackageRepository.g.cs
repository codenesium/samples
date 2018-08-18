using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface INuGetPackageRepository
	{
		Task<NuGetPackage> Create(NuGetPackage item);

		Task Update(NuGetPackage item);

		Task Delete(string id);

		Task<NuGetPackage> Get(string id);

		Task<List<NuGetPackage>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2cd2f85413c8212b7f92cfe453525a89</Hash>
</Codenesium>*/