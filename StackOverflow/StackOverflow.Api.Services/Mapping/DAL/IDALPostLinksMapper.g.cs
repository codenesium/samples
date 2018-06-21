using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IDALPostLinksMapper
        {
                PostLinks MapBOToEF(
                        BOPostLinks bo);

                BOPostLinks MapEFToBO(
                        PostLinks efPostLinks);

                List<BOPostLinks> MapEFToBO(
                        List<PostLinks> records);
        }
}

/*<Codenesium>
    <Hash>d4cdd53a8e3b8baa59a2db467027bc48</Hash>
</Codenesium>*/