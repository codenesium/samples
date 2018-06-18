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

                Task<List<NuGetPackage>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>50d39c211340770013d39ccaf489e9f7</Hash>
</Codenesium>*/