using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PhoneNumberType")]
	[Trait("Area", "ApiModel")]
	public class TestApiPhoneNumberTypeModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiPhoneNumberTypeModelMapper();
			var model = new ApiPhoneNumberTypeRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiPhoneNumberTypeResponseModel response = mapper.MapRequestToResponse(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.PhoneNumberTypeID.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiPhoneNumberTypeModelMapper();
			var model = new ApiPhoneNumberTypeResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiPhoneNumberTypeRequestModel response = mapper.MapResponseToRequest(model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPhoneNumberTypeModelMapper();
			var model = new ApiPhoneNumberTypeRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiPhoneNumberTypeRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPhoneNumberTypeRequestModel();
			patch.ApplyTo(response);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>b6d8baf4c5bd187a772e5b9510bd0e31</Hash>
</Codenesium>*/