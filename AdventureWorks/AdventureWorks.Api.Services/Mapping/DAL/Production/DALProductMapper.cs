using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductMapper: DALAbstractProductMapper, IDALProductMapper
        {
                public DALProductMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>88738f0b3df412c8281edff128ec405a</Hash>
</Codenesium>*/