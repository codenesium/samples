using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public interface IDALLinkLogMapper
        {
                LinkLog MapBOToEF(
                        BOLinkLog bo);

                BOLinkLog MapEFToBO(
                        LinkLog efLinkLog);

                List<BOLinkLog> MapEFToBO(
                        List<LinkLog> records);
        }
}

/*<Codenesium>
    <Hash>09d6fad5abedfce2927abfccfef27a6b</Hash>
</Codenesium>*/