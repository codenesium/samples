using Moq;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services.Tests
{
	public class BOLMapperMockFactory
	{
		public IBOLDirectTweetMapper BOLDirectTweetMapperMock { get; set; } = new BOLDirectTweetMapper();

		public IBOLFollowingMapper BOLFollowingMapperMock { get; set; } = new BOLFollowingMapper();

		public IBOLLikeMapper BOLLikeMapperMock { get; set; } = new BOLLikeMapper();

		public IBOLLocationMapper BOLLocationMapperMock { get; set; } = new BOLLocationMapper();

		public IBOLMessageMapper BOLMessageMapperMock { get; set; } = new BOLMessageMapper();

		public IBOLMessengerMapper BOLMessengerMapperMock { get; set; } = new BOLMessengerMapper();

		public IBOLQuoteTweetMapper BOLQuoteTweetMapperMock { get; set; } = new BOLQuoteTweetMapper();

		public IBOLReplyMapper BOLReplyMapperMock { get; set; } = new BOLReplyMapper();

		public IBOLRetweetMapper BOLRetweetMapperMock { get; set; } = new BOLRetweetMapper();

		public IBOLTweetMapper BOLTweetMapperMock { get; set; } = new BOLTweetMapper();

		public IBOLUserMapper BOLUserMapperMock { get; set; } = new BOLUserMapper();

		public BOLMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>85fc9b516c58c5422f83f6e4f8a32f05</Hash>
</Codenesium>*/