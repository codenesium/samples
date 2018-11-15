using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ErrorLog")]
	[Trait("Area", "ApiModel")]
	public class TestApiErrorLogModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiErrorLogModelMapper();
			var model = new ApiErrorLogClientRequestModel();
			model.SetProperties(1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiErrorLogClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.ErrorLine.Should().Be(1);
			response.ErrorMessage.Should().Be("A");
			response.ErrorNumber.Should().Be(1);
			response.ErrorProcedure.Should().Be("A");
			response.ErrorSeverity.Should().Be(1);
			response.ErrorState.Should().Be(1);
			response.ErrorTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.UserName.Should().Be("A");
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiErrorLogModelMapper();
			var model = new ApiErrorLogClientResponseModel();
			model.SetProperties(1, 1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiErrorLogClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.ErrorLine.Should().Be(1);
			response.ErrorMessage.Should().Be("A");
			response.ErrorNumber.Should().Be(1);
			response.ErrorProcedure.Should().Be("A");
			response.ErrorSeverity.Should().Be(1);
			response.ErrorState.Should().Be(1);
			response.ErrorTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.UserName.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>31297bc3d73f145f110c404f7bb1c367</Hash>
</Codenesium>*/