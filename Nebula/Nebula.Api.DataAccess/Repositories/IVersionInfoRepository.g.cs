using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
        public interface IVersionInfoRepository
        {
                Task<VersionInfo> Create(VersionInfo item);

                Task Update(VersionInfo item);

                Task Delete(long version);

                Task<VersionInfo> Get(long version);

                Task<List<VersionInfo>> All(int limit = int.MaxValue, int offset = 0);

                Task<VersionInfo> GetVersion(long version);
        }
}

/*<Codenesium>
    <Hash>fa99f674457fcaec9c29c67ecac9bcd8</Hash>
</Codenesium>*/