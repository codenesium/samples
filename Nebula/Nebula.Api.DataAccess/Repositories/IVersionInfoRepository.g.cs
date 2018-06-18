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

                Task<List<VersionInfo>> All(int limit = int.MaxValue, int offset = 0);

                Task<VersionInfo> GetVersion(long version);
        }
}

/*<Codenesium>
    <Hash>ffc1bd54cce414b5f9e358283ebc8025</Hash>
</Codenesium>*/