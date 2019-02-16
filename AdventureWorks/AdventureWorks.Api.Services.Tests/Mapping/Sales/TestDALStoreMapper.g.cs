using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Store")]
	[Trait("Area", "DALMapper")]
	public class TestDALStoreMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new DALStoreMapper();
			ApiStoreServerRequestModel model = new ApiStoreServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
			Store response = mapper.MapModelToBO(1, model);

			response.Demographic.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesPersonID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new DALStoreMapper();
			Store item = new Store();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
			ApiStoreServerResponseModel response = mapper.MapBOToModel(item);

			response.BusinessEntityID.Should().Be(1);
			response.Demographic.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.SalesPersonID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new DALStoreMapper();
			Store item = new Store();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
			List<ApiStoreServerResponseModel> response = mapper.MapBOToModel(new List<Store>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3436235608293f88fb55143b865481b8</Hash>
</Codenesium>*/