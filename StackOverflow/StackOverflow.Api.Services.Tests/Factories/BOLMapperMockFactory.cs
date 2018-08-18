using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services.Tests
{
	public class BOLMapperMockFactory
	{
		public IBOLBadgesMapper BOLBadgesMapperMock { get; set; } = new BOLBadgesMapper();

		public IBOLCommentsMapper BOLCommentsMapperMock { get; set; } = new BOLCommentsMapper();

		public IBOLLinkTypesMapper BOLLinkTypesMapperMock { get; set; } = new BOLLinkTypesMapper();

		public IBOLPostHistoryMapper BOLPostHistoryMapperMock { get; set; } = new BOLPostHistoryMapper();

		public IBOLPostHistoryTypesMapper BOLPostHistoryTypesMapperMock { get; set; } = new BOLPostHistoryTypesMapper();

		public IBOLPostLinksMapper BOLPostLinksMapperMock { get; set; } = new BOLPostLinksMapper();

		public IBOLPostsMapper BOLPostsMapperMock { get; set; } = new BOLPostsMapper();

		public IBOLPostTypesMapper BOLPostTypesMapperMock { get; set; } = new BOLPostTypesMapper();

		public IBOLTagsMapper BOLTagsMapperMock { get; set; } = new BOLTagsMapper();

		public IBOLUsersMapper BOLUsersMapperMock { get; set; } = new BOLUsersMapper();

		public IBOLVotesMapper BOLVotesMapperMock { get; set; } = new BOLVotesMapper();

		public IBOLVoteTypesMapper BOLVoteTypesMapperMock { get; set; } = new BOLVoteTypesMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>24d96bbc507d94dbc96d25d2caaa2f21</Hash>
</Codenesium>*/