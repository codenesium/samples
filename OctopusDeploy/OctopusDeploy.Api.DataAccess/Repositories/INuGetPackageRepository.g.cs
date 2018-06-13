using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface INuGetPackageRepository
        {
                Task<NuGetPackage> Create(NuGetPackage item);

                Task Update(NuGetPackage item);

                Task Delete(string id);

                Task<NuGetPackage> Get(string id);

                Task<List<NuGetPackage>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>7692484c4762bd8bde4e6d62c0cc934d</Hash>
</Codenesium>*/