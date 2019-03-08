using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Tags")]
	[Trait("Area", "DALMapper")]
	public class TestDALTagsMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTagsMapper();
			ApiTagsServerRequestModel model = new ApiTagsServerRequestModel();
			model.SetProperties(1, 1, "A", 1);
			Tags response = mapper.MapModelToEntity(1, model);

			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTagsMapper();
			Tags item = new Tags();
			item.SetProperties(1, 1, 1, "A", 1);
			ApiTagsServerResponseModel response = mapper.MapEntityToModel(item);

			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.Id.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTagsMapper();
			Tags item = new Tags();
			item.SetProperties(1, 1, 1, "A", 1);
			List<ApiTagsServerResponseModel> response = mapper.MapEntityToModel(new List<Tags>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>003c6246eb1ec8fe0401e4ac7e617552</Hash>
</Codenesium>*/