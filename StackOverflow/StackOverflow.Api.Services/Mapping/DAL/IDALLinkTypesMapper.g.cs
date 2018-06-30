using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IDALLinkTypesMapper
        {
                LinkTypes MapBOToEF(
                        BOLinkTypes bo);

                BOLinkTypes MapEFToBO(
                        LinkTypes efLinkTypes);

                List<BOLinkTypes> MapEFToBO(
                        List<LinkTypes> records);
        }
}

/*<Codenesium>
    <Hash>41ed64f8dc82d57e1e6277b43f823d8f</Hash>
</Codenesium>*/