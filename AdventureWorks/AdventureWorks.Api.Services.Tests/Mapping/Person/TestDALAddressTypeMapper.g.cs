using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "AddressType")]
	[Trait("Area", "DALMapper")]
	public class TestDALAddressTypeMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALAddressTypeMapper();
			ApiAddressTypeServerRequestModel model = new ApiAddressTypeServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			AddressType response = mapper.MapModelToEntity(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALAddressTypeMapper();
			AddressType item = new AddressType();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiAddressTypeServerResponseModel response = mapper.MapEntityToModel(item);

			response.AddressTypeID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALAddressTypeMapper();
			AddressType item = new AddressType();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			List<ApiAddressTypeServerResponseModel> response = mapper.MapEntityToModel(new List<AddressType>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>dc382b608e2ddae799d3dfb66dd9e02c</Hash>
</Codenesium>*/