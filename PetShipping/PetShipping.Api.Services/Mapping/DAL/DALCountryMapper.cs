using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class DALCountryMapper: DALAbstractCountryMapper, IDALCountryMapper
        {
                public DALCountryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>67ebda326784c8c40dd21a32aaf8857c</Hash>
</Codenesium>*/