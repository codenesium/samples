using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Messenger")]
	[Trait("Area", "DALMapper")]
	public class TestDALMessengerMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALMessengerMapper();
			var bo = new BOMessenger();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("0"), 1, 1);

			Messenger response = mapper.MapBOToEF(bo);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FromUserId.Should().Be(1);
			response.Id.Should().Be(1);
			response.MessageId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.ToUserId.Should().Be(1);
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALMessengerMapper();
			Messenger entity = new Messenger();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, TimeSpan.Parse("0"), 1, 1);

			BOMessenger response = mapper.MapEFToBO(entity);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FromUserId.Should().Be(1);
			response.Id.Should().Be(1);
			response.MessageId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("0"));
			response.ToUserId.Should().Be(1);
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALMessengerMapper();
			Messenger entity = new Messenger();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, TimeSpan.Parse("0"), 1, 1);

			List<BOMessenger> response = mapper.MapEFToBO(new List<Messenger>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>cef7fbc1ff3b0853ab34d94cf749139a</Hash>
</Codenesium>*/