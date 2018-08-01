using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface INuGetPackageRepository
	{
		Task<NuGetPackage> Create(NuGetPackage item);

		Task Update(NuGetPackage item);

		Task Delete(string id);

		Task<NuGetPackage> Get(string id);

		Task<List<NuGetPackage>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8e503b30f24cebfd80c335c3f9583140</Hash>
</Codenesium>*/