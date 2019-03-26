using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PhoneNumberType")]
	[Trait("Area", "ApiModel")]
	public class TestApiPhoneNumberTypeServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPhoneNumberTypeServerModelMapper();
			var model = new ApiPhoneNumberTypeServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiPhoneNumberTypeServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPhoneNumberTypeServerModelMapper();
			var model = new ApiPhoneNumberTypeServerResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiPhoneNumberTypeServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPhoneNumberTypeServerModelMapper();
			var model = new ApiPhoneNumberTypeServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiPhoneNumberTypeServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPhoneNumberTypeServerRequestModel();
			patch.ApplyTo(response);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>5f2e4cb26f69292dbc6a38b011e38741</Hash>
</Codenesium>*/