using FluentAssertions;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
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
			ApiFamilyServerRequestModel model = new ApiFamilyServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");
			BOFamily response = mapper.MapModelToBO(1, model);

			response.Note.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLFamilyMapper();
			BOFamily bo = new BOFamily();
			bo.SetProperties(1, "A", "A", "A", "A", "A");
			ApiFamilyServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLFamilyMapper();
			BOFamily bo = new BOFamily();
			bo.SetProperties(1, "A", "A", "A", "A", "A");
			List<ApiFamilyServerResponseModel> response = mapper.MapBOToModel(new List<BOFamily>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3a638424dc0b54eaf3516aa194007458</Hash>
</Codenesium>*/