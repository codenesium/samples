using FileServiceNS.Api.DataAccess;
using FileServiceNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Services.Tests
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
    <Hash>1ea788c806b0e590797a6a1b60265c4c</Hash>
</Codenesium>*/