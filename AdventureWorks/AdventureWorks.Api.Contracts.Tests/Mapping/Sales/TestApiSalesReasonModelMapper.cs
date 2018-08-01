using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SalesReason")]
	[Trait("Area", "ApiModel")]
	public class TestApiSalesReasonModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiSalesReasonModelMapper();
			var model = new ApiSalesReasonRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			ApiSalesReasonResponseModel response = mapper.MapRequestToResponse(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ReasonType.Should().Be("A");
			response.SalesReasonID.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiSalesReasonModelMapper();
			var model = new ApiSalesReasonResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");
			ApiSalesReasonRequestModel response = mapper.MapResponseToRequest(model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ReasonType.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiSalesReasonModelMapper();
			var model = new ApiSalesReasonRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A");

			JsonPatchDocument<ApiSalesReasonRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiSalesReasonRequestModel();
			patch.ApplyTo(response);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ReasonType.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>072f360fec7b3a8700fe74ff65708c1b</Hash>
</Codenesium>*/