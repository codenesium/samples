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
	[Trait("Table", "LinkType")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLLinkTypeMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLLinkTypeMapper();
			ApiLinkTypeServerRequestModel model = new ApiLinkTypeServerRequestModel();
			model.SetProperties("A");
			BOLinkType response = mapper.MapModelToBO(1, model);

			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLLinkTypeMapper();
			BOLinkType bo = new BOLinkType();
			bo.SetProperties(1, "A");
			ApiLinkTypeServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLLinkTypeMapper();
			BOLinkType bo = new BOLinkType();
			bo.SetProperties(1, "A");
			List<ApiLinkTypeServerResponseModel> response = mapper.MapBOToModel(new List<BOLinkType>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0812d0772a02081dc8b28c6de4258744</Hash>
</Codenesium>*/