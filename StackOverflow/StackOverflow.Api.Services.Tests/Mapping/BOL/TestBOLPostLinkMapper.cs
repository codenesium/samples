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
	[Trait("Table", "PostLink")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPostLinkMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPostLinkMapper();
			ApiPostLinkServerRequestModel model = new ApiPostLinkServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			BOPostLink response = mapper.MapModelToBO(1, model);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LinkTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RelatedPostId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPostLinkMapper();
			BOPostLink bo = new BOPostLink();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			ApiPostLinkServerResponseModel response = mapper.MapBOToModel(bo);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.LinkTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RelatedPostId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPostLinkMapper();
			BOPostLink bo = new BOPostLink();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			List<ApiPostLinkServerResponseModel> response = mapper.MapBOToModel(new List<BOPostLink>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7b14180606ed4e8a6fe6e3e67f2eefe6</Hash>
</Codenesium>*/