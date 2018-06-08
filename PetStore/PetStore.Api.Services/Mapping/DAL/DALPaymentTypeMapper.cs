using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public class DALPaymentTypeMapper: DALAbstractPaymentTypeMapper, IDALPaymentTypeMapper
        {
                public DALPaymentTypeMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>7f5b4d28fcdbdc6ec8adc0cd2dba7cd5</Hash>
</Codenesium>*/