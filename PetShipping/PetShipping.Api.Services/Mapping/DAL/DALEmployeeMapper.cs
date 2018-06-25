using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public partial class DALEmployeeMapper : DALAbstractEmployeeMapper, IDALEmployeeMapper
        {
                public DALEmployeeMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>dd111e74c08d30db15a602e02397eb99</Hash>
</Codenesium>*/