using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CustomerCommunication")]
	[Trait("Area", "ApiModel")]
	public class TestApiCustomerCommunicationServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCustomerCommunicationServerModelMapper();
			var model = new ApiCustomerCommunicationServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			ApiCustomerCommunicationServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.CustomerId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Note.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCustomerCommunicationServerModelMapper();
			var model = new ApiCustomerCommunicationServerResponseModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			ApiCustomerCommunicationServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.CustomerId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Note.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCustomerCommunicationServerModelMapper();
			var model = new ApiCustomerCommunicationServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

			JsonPatchDocument<ApiCustomerCommunicationServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCustomerCommunicationServerRequestModel();
			patch.ApplyTo(response);
			response.CustomerId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Note.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>47a8be0c38c6c029879f2b815078648e</Hash>
</Codenesium>*/