using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALPersonCreditCardMapper: DALAbstractPersonCreditCardMapper, IDALPersonCreditCardMapper
        {
                public DALPersonCreditCardMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>aa815ade38d863b91d781ecb893748ad</Hash>
</Codenesium>*/