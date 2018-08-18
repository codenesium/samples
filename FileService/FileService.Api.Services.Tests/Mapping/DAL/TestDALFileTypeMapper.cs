using FileServiceNS.Api.DataAccess;
using FileServiceNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "FileType")]
	[Trait("Area", "DALMapper")]
	public class TestDALFileTypeMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALFileTypeMapper();
			var bo = new BOFileType();
			bo.SetProperties(1, "A");

			FileType response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALFileTypeMapper();
			FileType entity = new FileType();
			entity.SetProperties(1, "A");

			BOFileType response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALFileTypeMapper();
			FileType entity = new FileType();
			entity.SetProperties(1, "A");

			List<BOFileType> response = mapper.MapEFToBO(new List<FileType>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>149885fe25661d9248325c0838bc8aa4</Hash>
</Codenesium>*/