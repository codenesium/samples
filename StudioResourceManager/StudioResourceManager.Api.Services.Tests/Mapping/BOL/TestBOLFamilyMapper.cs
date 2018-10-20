using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Family")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLFamilyMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLFamilyMapper();
			ApiFamilyRequestModel model = new ApiFamilyRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", true);
			BOFamily response = mapper.MapModelToBO(1, model);

			response.Note.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLFamilyMapper();
			BOFamily bo = new BOFamily();
			bo.SetProperties(1, "A", "A", "A", "A", "A", true);
			ApiFamilyResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLFamilyMapper();
			BOFamily bo = new BOFamily();
			bo.SetProperties(1, "A", "A", "A", "A", "A", true);
			List<ApiFamilyResponseModel> response = mapper.MapBOToModel(new List<BOFamily>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>fb3f83b1d64ab372c243d73cb5d618d6</Hash>
</Codenesium>*/