using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "AWBuildVersion")]
	[Trait("Area", "DALMapper")]
	public class TestDALAWBuildVersionMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new DALAWBuildVersionMapper();
			ApiAWBuildVersionServerRequestModel model = new ApiAWBuildVersionServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			AWBuildVersion response = mapper.MapModelToBO(1, model);

			response.Database_Version.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new DALAWBuildVersionMapper();
			AWBuildVersion item = new AWBuildVersion();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiAWBuildVersionServerResponseModel response = mapper.MapBOToModel(item);

			response.Database_Version.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SystemInformationID.Should().Be(1);
			response.VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new DALAWBuildVersionMapper();
			AWBuildVersion item = new AWBuildVersion();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			List<ApiAWBuildVersionServerResponseModel> response = mapper.MapBOToModel(new List<AWBuildVersion>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8e46026e7aa2906555d9965900d7b60b</Hash>
</Codenesium>*/