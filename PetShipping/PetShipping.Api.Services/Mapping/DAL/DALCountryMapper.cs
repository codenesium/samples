using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public partial class DALCountryMapper : DALAbstractCountryMapper, IDALCountryMapper
        {
                public DALCountryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>16c59aa39a575ea37e4a9135492534b4</Hash>
</Codenesium>*/