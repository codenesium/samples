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
	[Trait("Table", "Address")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLAddressMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLAddressMapper();
			ApiAddressServerRequestModel model = new ApiAddressServerRequestModel();
			model.SetProperties("A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
			BOAddress response = mapper.MapModelToBO(1, model);

			response.AddressLine1.Should().Be("A");
			response.AddressLine2.Should().Be("A");
			response.City.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostalCode.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLAddressMapper();
			BOAddress bo = new BOAddress();
			bo.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
			ApiAddressServerResponseModel response = mapper.MapBOToModel(bo);

			response.AddressID.Should().Be(1);
			response.AddressLine1.Should().Be("A");
			response.AddressLine2.Should().Be("A");
			response.City.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostalCode.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.StateProvinceID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLAddressMapper();
			BOAddress bo = new BOAddress();
			bo.SetProperties(1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
			List<ApiAddressServerResponseModel> response = mapper.MapBOToModel(new List<BOAddress>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5d541b52227e34d0143a8e86b5f1702e</Hash>
</Codenesium>*/