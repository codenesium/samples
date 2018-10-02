using Moq;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALBadgeMapper DALBadgeMapperMock { get; set; } = new DALBadgeMapper();

		public IDALCommentMapper DALCommentMapperMock { get; set; } = new DALCommentMapper();

		public IDALLinkTypeMapper DALLinkTypeMapperMock { get; set; } = new DALLinkTypeMapper();

		public IDALPostHistoryMapper DALPostHistoryMapperMock { get; set; } = new DALPostHistoryMapper();

		public IDALPostHistoryTypeMapper DALPostHistoryTypeMapperMock { get; set; } = new DALPostHistoryTypeMapper();

		public IDALPostLinkMapper DALPostLinkMapperMock { get; set; } = new DALPostLinkMapper();

		public IDALPostMapper DALPostMapperMock { get; set; } = new DALPostMapper();

		public IDALPostTypeMapper DALPostTypeMapperMock { get; set; } = new DALPostTypeMapper();

		public IDALTagMapper DALTagMapperMock { get; set; } = new DALTagMapper();

		public IDALUserMapper DALUserMapperMock { get; set; } = new DALUserMapper();

		public IDALVoteMapper DALVoteMapperMock { get; set; } = new DALVoteMapper();

		public IDALVoteTypeMapper DALVoteTypeMapperMock { get; set; } = new DALVoteTypeMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>eb66d8b2bc07d97eb8ed28930d61ac1a</Hash>
</Codenesium>*/