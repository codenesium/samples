using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>1fd149986f1b8db8d7aec60ab12893c2</Hash>
</Codenesium>*/