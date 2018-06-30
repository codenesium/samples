using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IDALBadgesMapper
        {
                Badges MapBOToEF(
                        BOBadges bo);

                BOBadges MapEFToBO(
                        Badges efBadges);

                List<BOBadges> MapEFToBO(
                        List<Badges> records);
        }
}

/*<Codenesium>
    <Hash>a9aed662af173a75f4047d2c05da3346</Hash>
</Codenesium>*/