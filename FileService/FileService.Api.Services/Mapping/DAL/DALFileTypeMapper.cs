using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public class DALFileTypeMapper: DALAbstractFileTypeMapper, IDALFileTypeMapper
        {
                public DALFileTypeMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>3225b542664fd0358d7fa430f38becb3</Hash>
</Codenesium>*/