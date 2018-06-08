using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class DALEmployeeMapper: DALAbstractEmployeeMapper, IDALEmployeeMapper
        {
                public DALEmployeeMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>e981ab6e3234ca6e969b915fd1a760f3</Hash>
</Codenesium>*/