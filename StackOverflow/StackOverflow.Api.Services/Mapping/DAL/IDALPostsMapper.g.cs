using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IDALPostsMapper
        {
                Posts MapBOToEF(
                        BOPosts bo);

                BOPosts MapEFToBO(
                        Posts efPosts);

                List<BOPosts> MapEFToBO(
                        List<Posts> records);
        }
}

/*<Codenesium>
    <Hash>e9d4326c7bb7479881bfe2a0a184b6ac</Hash>
</Codenesium>*/