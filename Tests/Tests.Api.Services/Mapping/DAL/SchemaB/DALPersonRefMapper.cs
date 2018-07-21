using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public partial class DALPersonRefMapper : DALAbstractPersonRefMapper, IDALPersonRefMapper
        {
                public DALPersonRefMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>887e44c084d2087c06cd9c202a47a5d7</Hash>
</Codenesium>*/