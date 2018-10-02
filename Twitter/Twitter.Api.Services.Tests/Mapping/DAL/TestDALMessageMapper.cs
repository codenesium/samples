using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Message")]
	[Trait("Area", "DALMapper")]
	public class TestDALMessageMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALMessageMapper();
			var bo = new BOMessage();
			bo.SetProperties(1, "A", 1);

			Message response = mapper.MapBOToEF(bo);

			response.Content.Should().Be("A");
			response.MessageId.Should().Be(1);
			response.SenderUserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALMessageMapper();
			Message entity = new Message();
			entity.SetProperties("A", 1, 1);

			BOMessage response = mapper.MapEFToBO(entity);

			response.Content.Should().Be("A");
			response.MessageId.Should().Be(1);
			response.SenderUserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALMessageMapper();
			Message entity = new Message();
			entity.SetProperties("A", 1, 1);

			List<BOMessage> response = mapper.MapEFToBO(new List<Message>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b166d58084cf2989934457741c10f0e3</Hash>
</Codenesium>*/