using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALLocationMapper: DALAbstractLocationMapper, IDALLocationMapper
        {
                public DALLocationMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>7854683154a9fdac18c9635234d8aa7f</Hash>
</Codenesium>*/