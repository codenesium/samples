using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
        public interface IDALFileMapper
        {
                File MapBOToEF(
                        BOFile bo);

                BOFile MapEFToBO(
                        File efFile);

                List<BOFile> MapEFToBO(
                        List<File> records);
        }
}

/*<Codenesium>
    <Hash>979b1d9999424da1ba96c420ef91c63e</Hash>
</Codenesium>*/