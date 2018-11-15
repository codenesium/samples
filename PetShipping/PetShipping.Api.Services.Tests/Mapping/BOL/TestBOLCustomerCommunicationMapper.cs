using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CustomerCommunication")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLCustomerCommunicationMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLCustomerCommunicationMapper();
			ApiCustomerCommunicationServerRequestModel model = new ApiCustomerCommunicationServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			BOCustomerCommunication response = mapper.MapModelToBO(1, model);

			response.CustomerId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Note.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLCustomerCommunicationMapper();
			BOCustomerCommunication bo = new BOCustomerCommunication();
			bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			ApiCustomerCommunicationServerResponseModel response = mapper.MapBOToModel(bo);

			response.CustomerId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLCustomerCommunicationMapper();
			BOCustomerCommunication bo = new BOCustomerCommunication();
			bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
			List<ApiCustomerCommunicationServerResponseModel> response = mapper.MapBOToModel(new List<BOCustomerCommunication>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>4a62c80d91ce35dc5355323e12fe64c7</Hash>
</Codenesium>*/