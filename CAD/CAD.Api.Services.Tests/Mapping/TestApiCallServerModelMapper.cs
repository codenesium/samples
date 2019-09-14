using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Call")]
	[Trait("Area", "ApiModel")]
	public class TestApiCallServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCallServerModelMapper();
			var model = new ApiCallServerRequestModel();
			model.SetProperties(1, 1, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiCallServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AddressId.Should().Be(1);
			response.CallDispositionId.Should().Be(1);
			response.CallStatusId.Should().Be(1);
			response.CallString.Should().Be("A");
			response.CallTypeId.Should().Be(1);
			response.DateCleared.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateDispatched.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.QuickCallNumber.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCallServerModelMapper();
			var model = new ApiCallServerResponseModel();
			model.SetProperties(1, 1, 1, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiCallServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.AddressId.Should().Be(1);
			response.CallDispositionId.Should().Be(1);
			response.CallStatusId.Should().Be(1);
			response.CallString.Should().Be("A");
			response.CallTypeId.Should().Be(1);
			response.DateCleared.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateDispatched.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.QuickCallNumber.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCallServerModelMapper();
			var model = new ApiCallServerRequestModel();
			model.SetProperties(1, 1, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

			JsonPatchDocument<ApiCallServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCallServerRequestModel();
			patch.ApplyTo(response);
			response.AddressId.Should().Be(1);
			response.CallDispositionId.Should().Be(1);
			response.CallStatusId.Should().Be(1);
			response.CallString.Should().Be("A");
			response.CallTypeId.Should().Be(1);
			response.DateCleared.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.DateDispatched.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.QuickCallNumber.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b85562d5a2d2f92eb8f7d984e6802e9b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/