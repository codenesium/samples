using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALCurrencyRateMapper: DALAbstractCurrencyRateMapper, IDALCurrencyRateMapper
        {
                public DALCurrencyRateMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>ede76d40e6566b035f1d05d7742a792f</Hash>
</Codenesium>*/