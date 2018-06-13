using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
        public interface IVersionInfoRepository
        {
                Task<VersionInfo> Create(VersionInfo item);

                Task Update(VersionInfo item);

                Task Delete(long version);

                Task<VersionInfo> Get(long version);

                Task<List<VersionInfo>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<VersionInfo> GetVersion(long version);
        }
}

/*<Codenesium>
    <Hash>45f9c26219adb66499e106be9eb365ff</Hash>
</Codenesium>*/