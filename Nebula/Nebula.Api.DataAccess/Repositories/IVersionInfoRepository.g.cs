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

                Task<VersionInfo> ByVersion(long version);
        }
}

/*<Codenesium>
    <Hash>091dfd78b7bbe9f822ed308e2f2c810e</Hash>
</Codenesium>*/