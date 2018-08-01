using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Shift")]
	[Trait("Area", "ApiModel")]
	public class TestApiShiftModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiShiftModelMapper();
			var model = new ApiShiftRequestModel();
			model.SetProperties(TimeSpan.Parse("0"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("0"));
			ApiShiftResponseModel response = mapper.MapRequestToResponse(1, model);

			response.EndTime.Should().Be(TimeSpan.Parse("0"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ShiftID.Should().Be(1);
			response.StartTime.Should().Be(TimeSpan.Parse("0"));
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiShiftModelMapper();
			var model = new ApiShiftResponseModel();
			model.SetProperties(1, TimeSpan.Parse("0"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("0"));
			ApiShiftRequestModel response = mapper.MapResponseToRequest(model);

			response.EndTime.Should().Be(TimeSpan.Parse("0"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.StartTime.Should().Be(TimeSpan.Parse("0"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiShiftModelMapper();
			var model = new ApiShiftRequestModel();
			model.SetProperties(TimeSpan.Parse("0"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("0"));

			JsonPatchDocument<ApiShiftRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiShiftRequestModel();
			patch.ApplyTo(response);
			response.EndTime.Should().Be(TimeSpan.Parse("0"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.StartTime.Should().Be(TimeSpan.Parse("0"));
		}
	}
}

/*<Codenesium>
    <Hash>9f4d861395297c626b687194a2ef5425</Hash>
</Codenesium>*/