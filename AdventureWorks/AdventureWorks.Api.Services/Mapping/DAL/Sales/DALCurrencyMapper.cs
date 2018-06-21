using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALCurrencyMapper : DALAbstractCurrencyMapper, IDALCurrencyMapper
        {
                public DALCurrencyMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>5d69afa7f19f09447539cf40afb2a298</Hash>
</Codenesium>*/