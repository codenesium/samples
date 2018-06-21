using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
        public interface IDALLinkStatusMapper
        {
                LinkStatus MapBOToEF(
                        BOLinkStatus bo);

                BOLinkStatus MapEFToBO(
                        LinkStatus efLinkStatus);

                List<BOLinkStatus> MapEFToBO(
                        List<LinkStatus> records);
        }
}

/*<Codenesium>
    <Hash>09e87ca208f95633865e51c83fd1d769</Hash>
</Codenesium>*/