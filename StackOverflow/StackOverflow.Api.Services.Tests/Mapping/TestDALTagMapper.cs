using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tag")]
	[Trait("Area", "DALMapper")]
	public class TestDALTagMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTagMapper();
			ApiTagServerRequestModel model = new ApiTagServerRequestModel();
			model.SetProperties(1, 1, "A", 1);
			Tag response = mapper.MapModelToEntity(1, model);

			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTagMapper();
			Tag item = new Tag();
			item.SetProperties(1, 1, 1, "A", 1);
			ApiTagServerResponseModel response = mapper.MapEntityToModel(item);

			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.Id.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTagMapper();
			Tag item = new Tag();
			item.SetProperties(1, 1, 1, "A", 1);
			List<ApiTagServerResponseModel> response = mapper.MapEntityToModel(new List<Tag>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>51331f4cbf679cec5fa645b717749f00</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/