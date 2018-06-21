using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>459973bc8b4de6bf9d651903995a3e0f</Hash>
</Codenesium>*/