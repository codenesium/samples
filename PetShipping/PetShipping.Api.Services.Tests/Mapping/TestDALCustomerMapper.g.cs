using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
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
			model.SetProperties("A", "A", "A", "A", "A");
			Customer response = mapper.MapModelToEntity(1, model);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Notes.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCustomerMapper();
			Customer item = new Customer();
			item.SetProperties(1, "A", "A", "A", "A", "A");
			ApiCustomerServerResponseModel response = mapper.MapEntityToModel(item);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Notes.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCustomerMapper();
			Customer item = new Customer();
			item.SetProperties(1, "A", "A", "A", "A", "A");
			List<ApiCustomerServerResponseModel> response = mapper.MapEntityToModel(new List<Customer>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>70188505c83ddb8001b6e12ef01c20da</Hash>
</Codenesium>*/