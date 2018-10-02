using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services.Tests
{
	public class BOLMapperMockFactory
	{
		public IBOLBadgeMapper BOLBadgeMapperMock { get; set; } = new BOLBadgeMapper();

		public IBOLCommentMapper BOLCommentMapperMock { get; set; } = new BOLCommentMapper();

		public IBOLLinkTypeMapper BOLLinkTypeMapperMock { get; set; } = new BOLLinkTypeMapper();

		public IBOLPostHistoryMapper BOLPostHistoryMapperMock { get; set; } = new BOLPostHistoryMapper();

		public IBOLPostHistoryTypeMapper BOLPostHistoryTypeMapperMock { get; set; } = new BOLPostHistoryTypeMapper();

		public IBOLPostLinkMapper BOLPostLinkMapperMock { get; set; } = new BOLPostLinkMapper();

		public IBOLPostMapper BOLPostMapperMock { get; set; } = new BOLPostMapper();

		public IBOLPostTypeMapper BOLPostTypeMapperMock { get; set; } = new BOLPostTypeMapper();

		public IBOLTagMapper BOLTagMapperMock { get; set; } = new BOLTagMapper();

		public IBOLUserMapper BOLUserMapperMock { get; set; } = new BOLUserMapper();

		public IBOLVoteMapper BOLVoteMapperMock { get; set; } = new BOLVoteMapper();

		public IBOLVoteTypeMapper BOLVoteTypeMapperMock { get; set; } = new BOLVoteTypeMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>2ce56a5f86ed98c0a9c83d8bb3af8523</Hash>
</Codenesium>*/