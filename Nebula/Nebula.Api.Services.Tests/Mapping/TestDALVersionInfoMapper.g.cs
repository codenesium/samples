using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VersionInfo")]
	[Trait("Area", "DALMapper")]
	public class TestDALVersionInfoMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALVersionInfoMapper();
			ApiVersionInfoServerRequestModel model = new ApiVersionInfoServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			VersionInfo response = mapper.MapModelToEntity(1, model);

			response.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALVersionInfoMapper();
			VersionInfo item = new VersionInfo();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiVersionInfoServerResponseModel response = mapper.MapEntityToModel(item);

			response.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALVersionInfoMapper();
			VersionInfo item = new VersionInfo();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiVersionInfoServerResponseModel> response = mapper.MapEntityToModel(new List<VersionInfo>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>81858358046c6468397655b4d8e0cb8d</Hash>
</Codenesium>*/