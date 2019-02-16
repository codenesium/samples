using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "FileType")]
	[Trait("Area", "DALMapper")]
	public class TestDALFileTypeMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALFileTypeMapper();
			ApiFileTypeServerRequestModel model = new ApiFileTypeServerRequestModel();
			model.SetProperties("A");
			FileType response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALFileTypeMapper();
			FileType item = new FileType();
			item.SetProperties(1, "A");
			ApiFileTypeServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALFileTypeMapper();
			FileType item = new FileType();
			item.SetProperties(1, "A");
			List<ApiFileTypeServerResponseModel> response = mapper.MapEntityToModel(new List<FileType>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>85108f1ffd3f43c2bff7f073afb9439d</Hash>
</Codenesium>*/