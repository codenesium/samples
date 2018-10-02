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
	[Trait("Table", "PostType")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPostTypeMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPostTypeMapper();
			ApiPostTypeRequestModel model = new ApiPostTypeRequestModel();
			model.SetProperties("A");
			BOPostType response = mapper.MapModelToBO(1, model);

			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPostTypeMapper();
			BOPostType bo = new BOPostType();
			bo.SetProperties(1, "A");
			ApiPostTypeResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPostTypeMapper();
			BOPostType bo = new BOPostType();
			bo.SetProperties(1, "A");
			List<ApiPostTypeResponseModel> response = mapper.MapBOToModel(new List<BOPostType>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9775b4586bc1608fa3b19f30c0dadec7</Hash>
</Codenesium>*/