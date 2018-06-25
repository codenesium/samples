using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALPersonCreditCardMapper : DALAbstractPersonCreditCardMapper, IDALPersonCreditCardMapper
        {
                public DALPersonCreditCardMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>cb9807ca7fc99eb4028ac4529d5d893e</Hash>
</Codenesium>*/