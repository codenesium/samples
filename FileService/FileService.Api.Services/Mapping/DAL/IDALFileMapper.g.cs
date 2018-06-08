using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

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
    <Hash>99b670e1ff3ae1f2d3afb846130db546</Hash>
</Codenesium>*/