using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VoteTypes")]
	[Trait("Area", "DALMapper")]
	public class TestDALVoteTypesMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALVoteTypesMapper();
			var bo = new BOVoteTypes();
			bo.SetProperties(1, "A");

			VoteTypes response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALVoteTypesMapper();
			VoteTypes entity = new VoteTypes();
			entity.SetProperties(1, "A");

			BOVoteTypes response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALVoteTypesMapper();
			VoteTypes entity = new VoteTypes();
			entity.SetProperties(1, "A");

			List<BOVoteTypes> response = mapper.MapEFToBO(new List<VoteTypes>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>dad3fc8c0adf50b13b202a467baa4c5f</Hash>
</Codenesium>*/