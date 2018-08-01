using FermataFishNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "StudentXFamily")]
	[Trait("Area", "ApiModel")]
	public class TestApiStudentXFamilyModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiStudentXFamilyModelMapper();
			var model = new ApiStudentXFamilyRequestModel();
			model.SetProperties(1, 1);
			ApiStudentXFamilyResponseModel response = mapper.MapRequestToResponse(1, model);

			response.FamilyId.Should().Be(1);
			response.Id.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiStudentXFamilyModelMapper();
			var model = new ApiStudentXFamilyResponseModel();
			model.SetProperties(1, 1, 1);
			ApiStudentXFamilyRequestModel response = mapper.MapResponseToRequest(model);

			response.FamilyId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiStudentXFamilyModelMapper();
			var model = new ApiStudentXFamilyRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiStudentXFamilyRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiStudentXFamilyRequestModel();
			patch.ApplyTo(response);
			response.FamilyId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2dc60410b2088d2912bfcb7f1623d556</Hash>
</Codenesium>*/