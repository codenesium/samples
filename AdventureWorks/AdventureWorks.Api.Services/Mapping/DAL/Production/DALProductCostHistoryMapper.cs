using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductCostHistoryMapper: DALAbstractProductCostHistoryMapper, IDALProductCostHistoryMapper
        {
                public DALProductCostHistoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>46c57e4f38fce680a83ac6cb73d091c9</Hash>
</Codenesium>*/