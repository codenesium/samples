using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>c505fe18d3a5bd696adda37b13877558</Hash>
</Codenesium>*/