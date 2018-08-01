using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "AWBuildVersion")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLAWBuildVersionMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLAWBuildVersionMapper();
			ApiAWBuildVersionRequestModel model = new ApiAWBuildVersionRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			BOAWBuildVersion response = mapper.MapModelToBO(1, model);

			response.Database_Version.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLAWBuildVersionMapper();
			BOAWBuildVersion bo = new BOAWBuildVersion();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiAWBuildVersionResponseModel response = mapper.MapBOToModel(bo);

			response.Database_Version.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.SystemInformationID.Should().Be(1);
			response.VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLAWBuildVersionMapper();
			BOAWBuildVersion bo = new BOAWBuildVersion();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
			List<ApiAWBuildVersionResponseModel> response = mapper.MapBOToModel(new List<BOAWBuildVersion>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>81e35afd75c75301d5e0a3e81b72e7a5</Hash>
</Codenesium>*/