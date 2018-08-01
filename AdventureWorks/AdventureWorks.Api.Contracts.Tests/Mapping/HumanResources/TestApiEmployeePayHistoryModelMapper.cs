using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EmployeePayHistory")]
	[Trait("Area", "ApiModel")]
	public class TestApiEmployeePayHistoryModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiEmployeePayHistoryModelMapper();
			var model = new ApiEmployeePayHistoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiEmployeePayHistoryResponseModel response = mapper.MapRequestToResponse(1, model);

			response.BusinessEntityID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PayFrequency.Should().Be(1);
			response.Rate.Should().Be(1m);
			response.RateChangeDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiEmployeePayHistoryModelMapper();
			var model = new ApiEmployeePayHistoryResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiEmployeePayHistoryRequestModel response = mapper.MapResponseToRequest(model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PayFrequency.Should().Be(1);
			response.Rate.Should().Be(1m);
			response.RateChangeDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEmployeePayHistoryModelMapper();
			var model = new ApiEmployeePayHistoryRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1m, DateTime.Parse("1/1/1987 12:00:00 AM"));

			JsonPatchDocument<ApiEmployeePayHistoryRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEmployeePayHistoryRequestModel();
			patch.ApplyTo(response);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PayFrequency.Should().Be(1);
			response.Rate.Should().Be(1m);
			response.RateChangeDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}
	}
}

/*<Codenesium>
    <Hash>ce43739f311e6fde053bb2db3a5e14bf</Hash>
</Codenesium>*/