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
			ApiPostHistoryTypeServerRequestModel model = new ApiPostHistoryTypeServerRequestModel();
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
			ApiPostHistoryTypeServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPostHistoryTypeMapper();
			BOPostHistoryType bo = new BOPostHistoryType();
			bo.SetProperties(1, "A");
			List<ApiPostHistoryTypeServerResponseModel> response = mapper.MapBOToModel(new List<BOPostHistoryType>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d1786723354e7603f281ce2cecf27b55</Hash>
</Codenesium>*/