using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ClientCommunication")]
	[Trait("Area", "ApiModel")]
	public class TestApiClientCommunicationServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiClientCommunicationServerModelMapper();
			var model = new ApiClientCommunicationServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			ApiClientCommunicationServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.ClientId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Note.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiClientCommunicationServerModelMapper();
			var model = new ApiClientCommunicationServerResponseModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			ApiClientCommunicationServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.ClientId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Note.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiClientCommunicationServerModelMapper();
			var model = new ApiClientCommunicationServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

			JsonPatchDocument<ApiClientCommunicationServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiClientCommunicationServerRequestModel();
			patch.ApplyTo(response);
			response.ClientId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Note.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>8fd1f0bc713277d77804da0c340f08f8</Hash>
</Codenesium>*/