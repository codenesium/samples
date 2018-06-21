using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
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
    <Hash>fdcd9e887c976147b781e28fcd0613dd</Hash>
</Codenesium>*/