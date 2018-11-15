using FluentAssertions;
using StudioResourceManagerMTNS.Api.DataAccess;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Family")]
	[Trait("Area", "DALMapper")]
	public class TestDALFamilyMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALFamilyMapper();
			var bo = new BOFamily();
			bo.SetProperties(1, "A", "A", "A", "A", "A");

			Family response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALFamilyMapper();
			Family entity = new Family();
			entity.SetProperties(1, "A", "A", "A", "A", "A");

			BOFamily response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
			response.PrimaryContactEmail.Should().Be("A");
			response.PrimaryContactFirstName.Should().Be("A");
			response.PrimaryContactLastName.Should().Be("A");
			response.PrimaryContactPhone.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALFamilyMapper();
			Family entity = new Family();
			entity.SetProperties(1, "A", "A", "A", "A", "A");

			List<BOFamily> response = mapper.MapEFToBO(new List<Family>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>dc329730eca51dcf466e96f857fb368d</Hash>
</Codenesium>*/