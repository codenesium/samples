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
	[Trait("Table", "PostLinks")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPostLinksMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPostLinksMapper();
			ApiPostLinksRequestModel model = new ApiPostLinksRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			BOPostLinks response = mapper.MapModelToBO(1, model);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LinkTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RelatedPostId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPostLinksMapper();
			BOPostLinks bo = new BOPostLinks();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			ApiPostLinksResponseModel response = mapper.MapBOToModel(bo);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.LinkTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RelatedPostId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPostLinksMapper();
			BOPostLinks bo = new BOPostLinks();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			List<ApiPostLinksResponseModel> response = mapper.MapBOToModel(new List<BOPostLinks>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a6c40941681f809f4df57dcb8a3aabd9</Hash>
</Codenesium>*/