using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>3850aabd37eadce8f12defa92d99d64f</Hash>
</Codenesium>*/