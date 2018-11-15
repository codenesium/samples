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
	[Trait("Table", "AddressType")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLAddressTypeMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLAddressTypeMapper();
			ApiAddressTypeServerRequestModel model = new ApiAddressTypeServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			BOAddressType response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLAddressTypeMapper();
			BOAddressType bo = new BOAddressType();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiAddressTypeServerResponseModel response = mapper.MapBOToModel(bo);

			response.AddressTypeID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLAddressTypeMapper();
			BOAddressType bo = new BOAddressType();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			List<ApiAddressTypeServerResponseModel> response = mapper.MapBOToModel(new List<BOAddressType>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>12233e2ff4bef5768b48c736d1a49ace</Hash>
</Codenesium>*/