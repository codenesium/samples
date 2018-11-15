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
	[Trait("Table", "Tag")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTagMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTagMapper();
			ApiTagServerRequestModel model = new ApiTagServerRequestModel();
			model.SetProperties(1, 1, "A", 1);
			BOTag response = mapper.MapModelToBO(1, model);

			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTagMapper();
			BOTag bo = new BOTag();
			bo.SetProperties(1, 1, 1, "A", 1);
			ApiTagServerResponseModel response = mapper.MapBOToModel(bo);

			response.Count.Should().Be(1);
			response.ExcerptPostId.Should().Be(1);
			response.Id.Should().Be(1);
			response.TagName.Should().Be("A");
			response.WikiPostId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTagMapper();
			BOTag bo = new BOTag();
			bo.SetProperties(1, 1, 1, "A", 1);
			List<ApiTagServerResponseModel> response = mapper.MapBOToModel(new List<BOTag>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>bd610436fae56adbe79a3b3802b99675</Hash>
</Codenesium>*/