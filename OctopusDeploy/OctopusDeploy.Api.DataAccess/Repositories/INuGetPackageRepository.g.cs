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
    <Hash>96b40c906abface3b4fd2bb99aea2440</Hash>
</Codenesium>*/