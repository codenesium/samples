using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>cabdbe64c43e641ef888e53cc5253d29</Hash>
</Codenesium>*/