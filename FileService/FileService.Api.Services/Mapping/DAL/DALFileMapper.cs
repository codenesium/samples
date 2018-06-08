using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public class DALFileMapper: DALAbstractFileMapper, IDALFileMapper
        {
                public DALFileMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>a7e5f6179f17953b8302a4273ae53600</Hash>
</Codenesium>*/