using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Shift")]
	[Trait("Area", "ApiModel")]
	public class TestApiShiftModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiShiftModelMapper();
			var model = new ApiShiftClientRequestModel();
			model.SetProperties(TimeSpan.Parse("01:00:00"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("01:00:00"));
			ApiShiftClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.EndTime.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.StartTime.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiShiftModelMapper();
			var model = new ApiShiftClientResponseModel();
			model.SetProperties(1, TimeSpan.Parse("01:00:00"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("01:00:00"));
			ApiShiftClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.EndTime.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.StartTime.Should().Be(TimeSpan.Parse("01:00:00"));
		}
	}
}

/*<Codenesium>
    <Hash>c4e688fae0ae6963a9242c7d1f2206e8</Hash>
</Codenesium>*/