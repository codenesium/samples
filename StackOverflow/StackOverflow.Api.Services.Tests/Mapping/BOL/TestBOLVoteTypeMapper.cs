using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VoteType")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLVoteTypeMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLVoteTypeMapper();
			ApiVoteTypeRequestModel model = new ApiVoteTypeRequestModel();
			model.SetProperties("A");
			BOVoteType response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLVoteTypeMapper();
			BOVoteType bo = new BOVoteType();
			bo.SetProperties(1, "A");
			ApiVoteTypeResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLVoteTypeMapper();
			BOVoteType bo = new BOVoteType();
			bo.SetProperties(1, "A");
			List<ApiVoteTypeResponseModel> response = mapper.MapBOToModel(new List<BOVoteType>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>167f6bd1627b79ab5d3936252071353e</Hash>
</Codenesium>*/