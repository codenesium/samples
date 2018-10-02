using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VoteType")]
	[Trait("Area", "DALMapper")]
	public class TestDALVoteTypeMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALVoteTypeMapper();
			var bo = new BOVoteType();
			bo.SetProperties(1, "A");

			VoteType response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALVoteTypeMapper();
			VoteType entity = new VoteType();
			entity.SetProperties(1, "A");

			BOVoteType response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALVoteTypeMapper();
			VoteType entity = new VoteType();
			entity.SetProperties(1, "A");

			List<BOVoteType> response = mapper.MapEFToBO(new List<VoteType>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e6e0c4dfe51162a674344a2228af3566</Hash>
</Codenesium>*/