using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public interface IDALFileTypeMapper
        {
                FileType MapBOToEF(
                        BOFileType bo);

                BOFileType MapEFToBO(
                        FileType efFileType);

                List<BOFileType> MapEFToBO(
                        List<FileType> records);
        }
}

/*<Codenesium>
    <Hash>6c33c455d208c9d35e13f073a60b831b</Hash>
</Codenesium>*/