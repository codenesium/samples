using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public class DALVersionInfoMapper: DALAbstractVersionInfoMapper, IDALVersionInfoMapper
        {
                public DALVersionInfoMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>0b45097319e1d5f4e543d7a4f007de77</Hash>
</Codenesium>*/