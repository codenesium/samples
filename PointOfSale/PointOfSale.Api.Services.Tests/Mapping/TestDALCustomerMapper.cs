using FluentAssertions;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PointOfSaleNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Customer")]
	[Trait("Area", "DALMapper")]
	public class TestDALCustomerMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCustomerMapper();
			ApiCustomerServerRequestModel model = new ApiCustomerServerRequestModel();
			model.SetProperties("A", "A", "A", "A");
			Customer response = mapper.MapModelToEntity(1, model);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCustomerMapper();
			Customer item = new Customer();
			item.SetProperties(1, "A", "A", "A", "A");
			ApiCustomerServerResponseModel response = mapper.MapEntityToModel(item);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCustomerMapper();
			Customer item = new Customer();
			item.SetProperties(1, "A", "A", "A", "A");
			List<ApiCustomerServerResponseModel> response = mapper.MapEntityToModel(new List<Customer>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b8856c56968437f47d43ed6e7dfb258d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/