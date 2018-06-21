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
    <Hash>bcf966c3f7cfcb9b7e2a6a1bb8a783b7</Hash>
</Codenesium>*/