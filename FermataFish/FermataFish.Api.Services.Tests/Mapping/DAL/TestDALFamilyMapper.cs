using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
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
			bo.SetProperties(1, "A", "A", "A", "A", "A", 1);

			Family response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Notes.Should().Be("A");
			response.PcEmail.Should().Be("A");
			response.PcFirstName.Should().Be("A");
			response.PcLastName.Should().Be("A");
			response.PcPhone.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALFamilyMapper();
			Family entity = new Family();
			entity.SetProperties(1, "A", "A", "A", "A", "A", 1);

			BOFamily response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Notes.Should().Be("A");
			response.PcEmail.Should().Be("A");
			response.PcFirstName.Should().Be("A");
			response.PcLastName.Should().Be("A");
			response.PcPhone.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALFamilyMapper();
			Family entity = new Family();
			entity.SetProperties(1, "A", "A", "A", "A", "A", 1);

			List<BOFamily> response = mapper.MapEFToBO(new List<Family>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>fe82b4f70fda198afc81ad7519e6a172</Hash>
</Codenesium>*/