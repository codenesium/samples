using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public partial class DALPersonMapper : DALAbstractPersonMapper, IDALPersonMapper
        {
                public DALPersonMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>ee3f1403991372d1d710dfb1e194fc15</Hash>
</Codenesium>*/