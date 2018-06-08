using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface IVersionInfoRepository
        {
                Task<VersionInfo> Create(VersionInfo item);

                Task Update(VersionInfo item);

                Task Delete(long version);

                Task<VersionInfo> Get(long version);

                Task<List<VersionInfo>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<VersionInfo> GetVersion(long version);
        }
}

/*<Codenesium>
    <Hash>fc2a123b0c9ce04a974a950dd521ae2c</Hash>
</Codenesium>*/