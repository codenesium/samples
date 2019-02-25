using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "BusinessEntity")]
	[Trait("Area", "DALMapper")]
	public class TestDALBusinessEntityMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALBusinessEntityMapper();
			ApiBusinessEntityServerRequestModel model = new ApiBusinessEntityServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			BusinessEntity response = mapper.MapModelToEntity(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALBusinessEntityMapper();
			BusinessEntity item = new BusinessEntity();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiBusinessEntityServerResponseModel response = mapper.MapEntityToModel(item);

			response.BusinessEntityID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALBusinessEntityMapper();
			BusinessEntity item = new BusinessEntity();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			List<ApiBusinessEntityServerResponseModel> response = mapper.MapEntityToModel(new List<BusinessEntity>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f461ec6866e4dbaf3daaece68aa52bee</Hash>
</Codenesium>*/