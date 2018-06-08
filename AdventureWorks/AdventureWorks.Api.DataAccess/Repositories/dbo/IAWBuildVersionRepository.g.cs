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
    <Hash>89c3680c471877c97a92157aa7a2dc21</Hash>
</Codenesium>*/