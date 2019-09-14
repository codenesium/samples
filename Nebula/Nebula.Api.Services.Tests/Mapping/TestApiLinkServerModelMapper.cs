using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Link")]
	[Trait("Area", "ApiModel")]
	public class TestApiLinkServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiLinkServerModelMapper();
			var model = new ApiLinkServerRequestModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);
			ApiLinkServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AssignedMachineId.Should().Be(1);
			response.ChainId.Should().Be(1);
			response.DateCompleted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateStarted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DynamicParameters.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.LinkStatusId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
			response.Response.Should().Be("A");
			response.StaticParameters.Should().Be("A");
			response.TimeoutInSeconds.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiLinkServerModelMapper();
			var model = new ApiLinkServerResponseModel();
			model.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);
			ApiLinkServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.AssignedMachineId.Should().Be(1);
			response.ChainId.Should().Be(1);
			response.DateCompleted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateStarted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DynamicParameters.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.LinkStatusId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
			response.Response.Should().Be("A");
			response.StaticParameters.Should().Be("A");
			response.TimeoutInSeconds.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiLinkServerModelMapper();
			var model = new ApiLinkServerRequestModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, "A", 1, "A", "A", 1);

			JsonPatchDocument<ApiLinkServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiLinkServerRequestModel();
			patch.ApplyTo(response);
			response.AssignedMachineId.Should().Be(1);
			response.ChainId.Should().Be(1);
			response.DateCompleted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateStarted.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DynamicParameters.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.LinkStatusId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
			response.Response.Should().Be("A");
			response.StaticParameters.Should().Be("A");
			response.TimeoutInSeconds.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1cc4015e1a7cfb86d960384ef10662aa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/