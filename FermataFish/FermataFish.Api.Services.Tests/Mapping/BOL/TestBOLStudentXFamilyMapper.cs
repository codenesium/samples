using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "StudentXFamily")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLStudentXFamilyMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLStudentXFamilyMapper();
			ApiStudentXFamilyRequestModel model = new ApiStudentXFamilyRequestModel();
			model.SetProperties(1, 1, 1);
			BOStudentXFamily response = mapper.MapModelToBO(1, model);

			response.FamilyId.Should().Be(1);
			response.StudentId.Should().Be(1);
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLStudentXFamilyMapper();
			BOStudentXFamily bo = new BOStudentXFamily();
			bo.SetProperties(1, 1, 1, 1);
			ApiStudentXFamilyResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.FamilyId.Should().Be(1);
			response.StudentId.Should().Be(1);
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLStudentXFamilyMapper();
			BOStudentXFamily bo = new BOStudentXFamily();
			bo.SetProperties(1, 1, 1, 1);
			List<ApiStudentXFamilyResponseModel> response = mapper.MapBOToModel(new List<BOStudentXFamily>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c7512fdb9a7a38124ed8ff1a34ca6c92</Hash>
</Codenesium>*/