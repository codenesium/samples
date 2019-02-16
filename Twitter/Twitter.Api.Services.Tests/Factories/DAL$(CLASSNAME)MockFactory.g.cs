using Moq;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

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
    <Hash>f4af6c53d93771d1c5a29962f992fad8</Hash>
</Codenesium>*/