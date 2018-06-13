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

                Task<List<AWBuildVersion>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>491415bf763a750d02ccbbdec6873c99</Hash>
</Codenesium>*/