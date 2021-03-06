using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CustomerCommunication")]
	[Trait("Area", "DALMapper")]
	public class TestDALCustomerCommunicationMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCustomerCommunicationMapper();
			ApiCustomerCommunicationServerRequestModel model = new ApiCustomerCommunicationServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			CustomerCommunication response = mapper.MapModelToEntity(1, model);

			response.CustomerId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Notes.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCustomerCommunicationMapper();
			CustomerCommunication item = new CustomerCommunication();
			item.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			ApiCustomerCommunicationServerResponseModel response = mapper.MapEntityToModel(item);

			response.CustomerId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Notes.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCustomerCommunicationMapper();
			CustomerCommunication item = new CustomerCommunication();
			item.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			List<ApiCustomerCommunicationServerResponseModel> response = mapper.MapEntityToModel(new List<CustomerCommunication>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a2f5b68403768c402b7af1c5ebf82829</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/