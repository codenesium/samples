using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostType")]
	[Trait("Area", "DALMapper")]
	public class TestDALPostTypeMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPostTypeMapper();
			ApiPostTypeServerRequestModel model = new ApiPostTypeServerRequestModel();
			model.SetProperties("A");
			PostType response = mapper.MapModelToEntity(1, model);

			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPostTypeMapper();
			PostType item = new PostType();
			item.SetProperties(1, "A");
			ApiPostTypeServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPostTypeMapper();
			PostType item = new PostType();
			item.SetProperties(1, "A");
			List<ApiPostTypeServerResponseModel> response = mapper.MapEntityToModel(new List<PostType>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>24480da8b10787f74cc79515ca8082b2</Hash>
</Codenesium>*/