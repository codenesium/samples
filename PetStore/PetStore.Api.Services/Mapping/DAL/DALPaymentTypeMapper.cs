using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public partial class DALPaymentTypeMapper : DALAbstractPaymentTypeMapper, IDALPaymentTypeMapper
        {
                public DALPaymentTypeMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>a23efb567eae0bfc93021816345567d4</Hash>
</Codenesium>*/