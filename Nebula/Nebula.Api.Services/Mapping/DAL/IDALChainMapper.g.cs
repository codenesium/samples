using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public interface IDALChainMapper
        {
                Chain MapBOToEF(
                        BOChain bo);

                BOChain MapEFToBO(
                        Chain efChain);

                List<BOChain> MapEFToBO(
                        List<Chain> records);
        }
}

/*<Codenesium>
    <Hash>71559c128797878ced22155ba79e6ab5</Hash>
</Codenesium>*/