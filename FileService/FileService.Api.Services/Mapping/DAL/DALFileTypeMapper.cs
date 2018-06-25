using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FileServiceNS.Api.Services
{
        public partial class DALFileTypeMapper : DALAbstractFileTypeMapper, IDALFileTypeMapper
        {
                public DALFileTypeMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>dc0c7f9ec1d0134436db57b7266e1a2d</Hash>
</Codenesium>*/