using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Link")]
	[Trait("Area", "ApiModel")]
	public class TestApiLinkModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiLinkModelMapper();
			var model = new ApiLinkClientRequestModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);
			ApiLinkClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
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
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiLinkModelMapper();
			var model = new ApiLinkClientResponseModel();
			model.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);
			ApiLinkClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
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
	}
}

/*<Codenesium>
    <Hash>d504791c22d12d6f12d22d69c199d01c</Hash>
</Codenesium>*/