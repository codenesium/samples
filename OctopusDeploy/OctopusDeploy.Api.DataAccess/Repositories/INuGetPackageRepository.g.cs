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

                Task<List<NuGetPackage>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>1ccd8277059616881b7c24b5eb4d1ad3</Hash>
</Codenesium>*/