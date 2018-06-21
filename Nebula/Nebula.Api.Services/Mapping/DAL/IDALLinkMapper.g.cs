using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>f68fa9868c983153bcb4b13eced644b7</Hash>
</Codenesium>*/