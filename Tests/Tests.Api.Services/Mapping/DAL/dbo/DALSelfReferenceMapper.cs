using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public partial class DALSelfReferenceMapper : DALAbstractSelfReferenceMapper, IDALSelfReferenceMapper
        {
                public DALSelfReferenceMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>fa3c066a2993576de18e23bf27cb23c4</Hash>
</Codenesium>*/