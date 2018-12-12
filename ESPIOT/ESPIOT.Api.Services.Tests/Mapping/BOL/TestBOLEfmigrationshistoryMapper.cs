using ESPIOTNS.Api.Contracts;
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
	[Trait("Area", "BOLMapper")]
	public class TestBOLEfmigrationshistoryMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLEfmigrationshistoryMapper();
			ApiEfmigrationshistoryServerRequestModel model = new ApiEfmigrationshistoryServerRequestModel();
			model.SetProperties("A");
			BOEfmigrationshistory response = mapper.MapModelToBO("A", model);

			response.ProductVersion.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLEfmigrationshistoryMapper();
			BOEfmigrationshistory bo = new BOEfmigrationshistory();
			bo.SetProperties("A", "A");
			ApiEfmigrationshistoryServerResponseModel response = mapper.MapBOToModel(bo);

			response.MigrationId.Should().Be("A");
			response.ProductVersion.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLEfmigrationshistoryMapper();
			BOEfmigrationshistory bo = new BOEfmigrationshistory();
			bo.SetProperties("A", "A");
			List<ApiEfmigrationshistoryServerResponseModel> response = mapper.MapBOToModel(new List<BOEfmigrationshistory>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>eb9e2eea59ab2368022397d25883ebd7</Hash>
</Codenesium>*/