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
	[Trait("Table", "PostHistoryType")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPostHistoryTypeMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPostHistoryTypeMapper();
			ApiPostHistoryTypeRequestModel model = new ApiPostHistoryTypeRequestModel();
			model.SetProperties("A");
			BOPostHistoryType response = mapper.MapModelToBO(1, model);

			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPostHistoryTypeMapper();
			BOPostHistoryType bo = new BOPostHistoryType();
			bo.SetProperties(1, "A");
			ApiPostHistoryTypeResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPostHistoryTypeMapper();
			BOPostHistoryType bo = new BOPostHistoryType();
			bo.SetProperties(1, "A");
			List<ApiPostHistoryTypeResponseModel> response = mapper.MapBOToModel(new List<BOPostHistoryType>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7d5cb8b2cd20b5bb2c62c23b7db96b96</Hash>
</Codenesium>*/