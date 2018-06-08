using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

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
    <Hash>e693e920d58f086de9f6cbcc848c8022</Hash>
</Codenesium>*/