using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Link")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLLinkMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLLinkMapper();
			ApiLinkServerRequestModel model = new ApiLinkServerRequestModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);
			BOLink response = mapper.MapModelToBO(1, model);

			response.AssignedMachineId.Should().Be(1);
			response.ChainId.Should().Be(1);
			response.DateCompleted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateStarted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DynamicParameter.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.LinkStatusId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
			response.Response.Should().Be("A");
			response.StaticParameter.Should().Be("A");
			response.TimeoutInSecond.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLLinkMapper();
			BOLink bo = new BOLink();
			bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);
			ApiLinkServerResponseModel response = mapper.MapBOToModel(bo);

			response.AssignedMachineId.Should().Be(1);
			response.ChainId.Should().Be(1);
			response.DateCompleted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateStarted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DynamicParameter.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Id.Should().Be(1);
			response.LinkStatusId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
			response.Response.Should().Be("A");
			response.StaticParameter.Should().Be("A");
			response.TimeoutInSecond.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLLinkMapper();
			BOLink bo = new BOLink();
			bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);
			List<ApiLinkServerResponseModel> response = mapper.MapBOToModel(new List<BOLink>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>055f9387a3cca4c27d0915f591b53942</Hash>
</Codenesium>*/