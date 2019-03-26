using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VoteType")]
	[Trait("Area", "DALMapper")]
	public class TestDALVoteTypeMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALVoteTypeMapper();
			ApiVoteTypeServerRequestModel model = new ApiVoteTypeServerRequestModel();
			model.SetProperties("A");
			VoteType response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALVoteTypeMapper();
			VoteType item = new VoteType();
			item.SetProperties(1, "A");
			ApiVoteTypeServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALVoteTypeMapper();
			VoteType item = new VoteType();
			item.SetProperties(1, "A");
			List<ApiVoteTypeServerResponseModel> response = mapper.MapEntityToModel(new List<VoteType>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c60cdd3744aec2749cbb586bd339fa71</Hash>
</Codenesium>*/