using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

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
    <Hash>82f7cabb27bf0549fc5c4ddbebcc9d26</Hash>
</Codenesium>*/