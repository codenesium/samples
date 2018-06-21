using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>fd4f221db5d8c5e563d8df98e189ac02</Hash>
</Codenesium>*/