using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IDALCommentsMapper
        {
                Comments MapBOToEF(
                        BOComments bo);

                BOComments MapEFToBO(
                        Comments efComments);

                List<BOComments> MapEFToBO(
                        List<Comments> records);
        }
}

/*<Codenesium>
    <Hash>dbef9e01dfe51ed4db0dffa6fb4bf21d</Hash>
</Codenesium>*/