using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Department")]
	[Trait("Area", "ApiModel")]
	public class TestApiDepartmentModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiDepartmentModelMapper();
			var model = new ApiDepartmentRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiDepartmentResponseModel response = mapper.MapRequestToResponse(1, model);

			response.DepartmentID.Should().Be(1);
			response.GroupName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiDepartmentModelMapper();
			var model = new ApiDepartmentResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiDepartmentRequestModel response = mapper.MapResponseToRequest(model);

			response.GroupName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiDepartmentModelMapper();
			var model = new ApiDepartmentRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			JsonPatchDocument<ApiDepartmentRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiDepartmentRequestModel();
			patch.ApplyTo(response);
			response.GroupName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>ee0a3b0a3b3a7c4f6334f94d3a32e9ee</Hash>
</Codenesium>*/