using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public interface IDALChainStatusMapper
        {
                ChainStatus MapBOToEF(
                        BOChainStatus bo);

                BOChainStatus MapEFToBO(
                        ChainStatus efChainStatus);

                List<BOChainStatus> MapEFToBO(
                        List<ChainStatus> records);
        }
}

/*<Codenesium>
    <Hash>0926412d2a96b9ef195fc451a277f86b</Hash>
</Codenesium>*/