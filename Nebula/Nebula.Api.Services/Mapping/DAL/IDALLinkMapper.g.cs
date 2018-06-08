using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface IDALLinkMapper
        {
                Link MapBOToEF(
                        BOLink bo);

                BOLink MapEFToBO(
                        Link efLink);

                List<BOLink> MapEFToBO(
                        List<Link> records);
        }
}

/*<Codenesium>
    <Hash>3a66ba111bbc7e3870ba37ab9b56841f</Hash>
</Codenesium>*/