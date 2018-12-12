using ESPIOTNS.Api.DataAccess;
using ESPIOTNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESPIOTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Efmigrationshistory")]
	[Trait("Area", "DALMapper")]
	public class TestDALEfmigrationshistoryMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALEfmigrationshistoryMapper();
			var bo = new BOEfmigrationshistory();
			bo.SetProperties("A", "A");

			Efmigrationshistory response = mapper.MapBOToEF(bo);

			response.MigrationId.Should().Be("A");
			response.ProductVersion.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALEfmigrationshistoryMapper();
			Efmigrationshistory entity = new Efmigrationshistory();
			entity.SetProperties("A", "A");

			BOEfmigrationshistory response = mapper.MapEFToBO(entity);

			response.MigrationId.Should().Be("A");
			response.ProductVersion.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALEfmigrationshistoryMapper();
			Efmigrationshistory entity = new Efmigrationshistory();
			entity.SetProperties("A", "A");

			List<BOEfmigrationshistory> response = mapper.MapEFToBO(new List<Efmigrationshistory>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>09bb9aedde1250899e871d14b5793b04</Hash>
</Codenesium>*/