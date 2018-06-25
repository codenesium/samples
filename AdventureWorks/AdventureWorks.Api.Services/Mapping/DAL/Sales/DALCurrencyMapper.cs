using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALCurrencyMapper : DALAbstractCurrencyMapper, IDALCurrencyMapper
        {
                public DALCurrencyMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>0bf3bb8b732e12f7237b40d8380bd333</Hash>
</Codenesium>*/