using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALCurrencyMapper: DALAbstractCurrencyMapper, IDALCurrencyMapper
        {
                public DALCurrencyMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>0578dfd669a3fa620590dd2154fcd95a</Hash>
</Codenesium>*/