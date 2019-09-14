using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Address")]
	[Trait("Area", "DALMapper")]
	public class TestDALAddressMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALAddressMapper();
			ApiAddressServerRequestModel model = new ApiAddressServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");
			Address response = mapper.MapModelToEntity(1, model);

			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.State.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALAddressMapper();
			Address item = new Address();
			item.SetProperties(1, "A", "A", "A", "A", "A");
			ApiAddressServerResponseModel response = mapper.MapEntityToModel(item);

			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Id.Should().Be(1);
			response.State.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALAddressMapper();
			Address item = new Address();
			item.SetProperties(1, "A", "A", "A", "A", "A");
			List<ApiAddressServerResponseModel> response = mapper.MapEntityToModel(new List<Address>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ecade1cafdbe17fc29ae646794516882</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/