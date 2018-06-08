using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class DALCountryRequirementMapper: DALAbstractCountryRequirementMapper, IDALCountryRequirementMapper
        {
                public DALCountryRequirementMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>f435e65922743142539c799d40b3d7dd</Hash>
</Codenesium>*/