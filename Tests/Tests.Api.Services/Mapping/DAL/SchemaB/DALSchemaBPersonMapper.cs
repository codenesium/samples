using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public partial class DALSchemaBPersonMapper : DALAbstractSchemaBPersonMapper, IDALSchemaBPersonMapper
        {
                public DALSchemaBPersonMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>095c9cf7fae7377452f277f8a4cf11b4</Hash>
</Codenesium>*/