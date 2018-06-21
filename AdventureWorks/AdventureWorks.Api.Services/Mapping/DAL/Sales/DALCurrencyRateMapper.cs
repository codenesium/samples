using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALCurrencyRateMapper : DALAbstractCurrencyRateMapper, IDALCurrencyRateMapper
        {
                public DALCurrencyRateMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>c23dbe7a121cefa67c731481c35d7c6d</Hash>
</Codenesium>*/