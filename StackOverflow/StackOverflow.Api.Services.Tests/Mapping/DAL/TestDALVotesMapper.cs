using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Votes")]
	[Trait("Area", "DALMapper")]
	public class TestDALVotesMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALVotesMapper();
			var bo = new BOVotes();
			bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);

			Votes response = mapper.MapBOToEF(bo);

			response.BountyAmount.Should().Be(1);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.PostId.Should().Be(1);
			response.UserId.Should().Be(1);
			response.VoteTypeId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALVotesMapper();
			Votes entity = new Votes();
			entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1);

			BOVotes response = mapper.MapEFToBO(entity);

			response.BountyAmount.Should().Be(1);
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.PostId.Should().Be(1);
			response.UserId.Should().Be(1);
			response.VoteTypeId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALVotesMapper();
			Votes entity = new Votes();
			entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1, 1);

			List<BOVotes> response = mapper.MapEFToBO(new List<Votes>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>10864524af0b8047ad064e188b33f5b5</Hash>
</Codenesium>*/