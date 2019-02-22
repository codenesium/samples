using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Call")]
	[Trait("Area", "ApiModel")]
	public class TestApiCallModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiCallModelMapper();
			var model = new ApiCallClientRequestModel();
			model.SetProperties(1, 1, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiCallClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
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
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiCallModelMapper();
			var model = new ApiCallClientResponseModel();
			model.SetProperties(1, 1, 1, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			ApiCallClientRequestModel response = mapper.MapClientResponseToRequest(model);
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
	}
}

/*<Codenesium>
    <Hash>22fddec4e2644ed2f596ff7dbdc1276a</Hash>
</Codenesium>*/