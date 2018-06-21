using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
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
    <Hash>9a96c76032af5123fd7eb0580528841c</Hash>
</Codenesium>*/