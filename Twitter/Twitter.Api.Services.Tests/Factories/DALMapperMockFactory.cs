using Moq;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;

namespace TwitterNS.Api.Services.Tests
{
	public class DALMapperMockFactory
	{
		public IDALDirectTweetMapper DALDirectTweetMapperMock { get; set; } = new DALDirectTweetMapper();

		public IDALFollowerMapper DALFollowerMapperMock { get; set; } = new DALFollowerMapper();

		public IDALFollowingMapper DALFollowingMapperMock { get; set; } = new DALFollowingMapper();

		public IDALLocationMapper DALLocationMapperMock { get; set; } = new DALLocationMapper();

		public IDALMessageMapper DALMessageMapperMock { get; set; } = new DALMessageMapper();

		public IDALMessengerMapper DALMessengerMapperMock { get; set; } = new DALMessengerMapper();

		public IDALQuoteTweetMapper DALQuoteTweetMapperMock { get; set; } = new DALQuoteTweetMapper();

		public IDALReplyMapper DALReplyMapperMock { get; set; } = new DALReplyMapper();

		public IDALRetweetMapper DALRetweetMapperMock { get; set; } = new DALRetweetMapper();

		public IDALTweetMapper DALTweetMapperMock { get; set; } = new DALTweetMapper();

		public IDALUserMapper DALUserMapperMock { get; set; } = new DALUserMapper();

		public DALMapperMockFactory()
		{
		}
	}
}

/*<Codenesium>
    <Hash>6247638082312709fbe8c8cb30bbfbb9</Hash>
</Codenesium>*/