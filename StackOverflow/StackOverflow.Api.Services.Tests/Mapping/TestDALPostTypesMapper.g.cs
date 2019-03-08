using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostTypes")]
	[Trait("Area", "DALMapper")]
	public class TestDALPostTypesMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPostTypesMapper();
			ApiPostTypesServerRequestModel model = new ApiPostTypesServerRequestModel();
			model.SetProperties("A");
			PostTypes response = mapper.MapModelToEntity(1, model);

			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPostTypesMapper();
			PostTypes item = new PostTypes();
			item.SetProperties(1, "A");
			ApiPostTypesServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.RwType.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPostTypesMapper();
			PostTypes item = new PostTypes();
			item.SetProperties(1, "A");
			List<ApiPostTypesServerResponseModel> response = mapper.MapEntityToModel(new List<PostTypes>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9263b4b6d4d75162dff332c94dbd28be</Hash>
</Codenesium>*/