using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ErrorLog")]
	[Trait("Area", "ApiModel")]
	public class TestApiErrorLogServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiErrorLogServerModelMapper();
			var model = new ApiErrorLogServerRequestModel();
			model.SetProperties(1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiErrorLogServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
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
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiErrorLogServerModelMapper();
			var model = new ApiErrorLogServerResponseModel();
			model.SetProperties(1, 1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiErrorLogServerRequestModel response = mapper.MapServerResponseToRequest(model);
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
		public void CreatePatch()
		{
			var mapper = new ApiErrorLogServerModelMapper();
			var model = new ApiErrorLogServerRequestModel();
			model.SetProperties(1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiErrorLogServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiErrorLogServerRequestModel();
			patch.ApplyTo(response);
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
    <Hash>d8f393fc7e3b48cb47fedc08e1436e54</Hash>
</Codenesium>*/