using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IDALFamilyMapper
        {
                Family MapBOToEF(
                        BOFamily bo);

                BOFamily MapEFToBO(
                        Family efFamily);

                List<BOFamily> MapEFToBO(
                        List<Family> records);
        }
}

/*<Codenesium>
    <Hash>3ec4bed4aa119e81195a6d0b32c98291</Hash>
</Codenesium>*/