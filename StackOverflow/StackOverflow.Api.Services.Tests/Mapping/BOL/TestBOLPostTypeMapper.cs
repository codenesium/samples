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
			ApiPostTypeServerRequestModel model = new ApiPostTypeServerRequestModel();
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
			ApiPostTypeServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPostTypeMapper();
			BOPostType bo = new BOPostType();
			bo.SetProperties(1, "A");
			List<ApiPostTypeServerResponseModel> response = mapper.MapBOToModel(new List<BOPostType>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d30d6f7919fdc3081f0f1009f5e765a2</Hash>
</Codenesium>*/