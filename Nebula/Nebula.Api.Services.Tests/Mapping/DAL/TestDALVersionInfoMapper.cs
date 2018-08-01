using FluentAssertions;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VersionInfo")]
	[Trait("Area", "DALMapper")]
	public class TestDALVersionInfoMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALVersionInfoMapper();
			var bo = new BOVersionInfo();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			VersionInfo response = mapper.MapBOToEF(bo);

			response.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALVersionInfoMapper();
			VersionInfo entity = new VersionInfo();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

			BOVersionInfo response = mapper.MapEFToBO(entity);

			response.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALVersionInfoMapper();
			VersionInfo entity = new VersionInfo();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);

			List<BOVersionInfo> response = mapper.MapEFToBO(new List<VersionInfo>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7cb3231b0bd7abf352e3e6554b7bbb65</Hash>
</Codenesium>*/