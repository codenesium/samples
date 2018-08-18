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
	[Trait("Table", "BusinessEntity")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLBusinessEntityMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLBusinessEntityMapper();
			ApiBusinessEntityRequestModel model = new ApiBusinessEntityRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			BOBusinessEntity response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLBusinessEntityMapper();
			BOBusinessEntity bo = new BOBusinessEntity();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiBusinessEntityResponseModel response = mapper.MapBOToModel(bo);

			response.BusinessEntityID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLBusinessEntityMapper();
			BOBusinessEntity bo = new BOBusinessEntity();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			List<ApiBusinessEntityResponseModel> response = mapper.MapBOToModel(new List<BOBusinessEntity>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b87662f5126cbdccd0b8b6b0a93863ae</Hash>
</Codenesium>*/