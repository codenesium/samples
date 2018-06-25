using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FileServiceNS.Api.Services
{
        public partial class DALFileMapper : DALAbstractFileMapper, IDALFileMapper
        {
                public DALFileMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>afa326af164ba540a0e03f9e508fd25a</Hash>
</Codenesium>*/