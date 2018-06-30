using Moq;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services.Tests
{
        public class DALMapperMockFactory
        {
                public IDALBadgesMapper DALBadgesMapperMock { get; set; } = new DALBadgesMapper();

                public IDALCommentsMapper DALCommentsMapperMock { get; set; } = new DALCommentsMapper();

                public IDALLinkTypesMapper DALLinkTypesMapperMock { get; set; } = new DALLinkTypesMapper();

                public IDALPostHistoryMapper DALPostHistoryMapperMock { get; set; } = new DALPostHistoryMapper();

                public IDALPostHistoryTypesMapper DALPostHistoryTypesMapperMock { get; set; } = new DALPostHistoryTypesMapper();

                public IDALPostLinksMapper DALPostLinksMapperMock { get; set; } = new DALPostLinksMapper();

                public IDALPostsMapper DALPostsMapperMock { get; set; } = new DALPostsMapper();

                public IDALPostTypesMapper DALPostTypesMapperMock { get; set; } = new DALPostTypesMapper();

                public IDALTagsMapper DALTagsMapperMock { get; set; } = new DALTagsMapper();

                public IDALUsersMapper DALUsersMapperMock { get; set; } = new DALUsersMapper();

                public IDALVotesMapper DALVotesMapperMock { get; set; } = new DALVotesMapper();

                public IDALVoteTypesMapper DALVoteTypesMapperMock { get; set; } = new DALVoteTypesMapper();

                public DALMapperMockFactory()
                {
                }
        }
}

/*<Codenesium>
    <Hash>35758accfa633c9d32c60aadd34d1641</Hash>
</Codenesium>*/