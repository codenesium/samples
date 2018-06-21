using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public class DALPaymentTypeMapper : DALAbstractPaymentTypeMapper, IDALPaymentTypeMapper
        {
                public DALPaymentTypeMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>da29424ffbac997814b87efb6bb367ea</Hash>
</Codenesium>*/