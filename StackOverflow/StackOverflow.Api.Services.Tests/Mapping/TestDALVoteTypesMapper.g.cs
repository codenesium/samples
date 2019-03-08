using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VoteTypes")]
	[Trait("Area", "DALMapper")]
	public class TestDALVoteTypesMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALVoteTypesMapper();
			ApiVoteTypesServerRequestModel model = new ApiVoteTypesServerRequestModel();
			model.SetProperties("A");
			VoteTypes response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALVoteTypesMapper();
			VoteTypes item = new VoteTypes();
			item.SetProperties(1, "A");
			ApiVoteTypesServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALVoteTypesMapper();
			VoteTypes item = new VoteTypes();
			item.SetProperties(1, "A");
			List<ApiVoteTypesServerResponseModel> response = mapper.MapEntityToModel(new List<VoteTypes>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>533b3b29dcc45befa2df9fa4ded4e703</Hash>
</Codenesium>*/