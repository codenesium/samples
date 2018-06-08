using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface IDALVersionInfoMapper
        {
                VersionInfo MapBOToEF(
                        BOVersionInfo bo);

                BOVersionInfo MapEFToBO(
                        VersionInfo efVersionInfo);

                List<BOVersionInfo> MapEFToBO(
                        List<VersionInfo> records);
        }
}

/*<Codenesium>
    <Hash>e7f61ecdbc50767a152a593b09713e25</Hash>
</Codenesium>*/