using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Family")]
	[Trait("Area", "DALMapper")]
	public class TestDALFamilyMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALFamilyMapper();
			ApiFamilyServerRequestModel model = new ApiFamilyServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");
			Family response = mapper.MapModelToEntity(1, model);

			response.Notes.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALFamilyMapper();
			Family item = new Family();
			item.SetProperties(1, "A", "A", "A", "A", "A");
			ApiFamilyServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Notes.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALFamilyMapper();
			Family item = new Family();
			item.SetProperties(1, "A", "A", "A", "A", "A");
			List<ApiFamilyServerResponseModel> response = mapper.MapEntityToModel(new List<Family>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ee7c3f3da76feca9a4dfb8ad7dedadf5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/