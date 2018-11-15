using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Customer")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLCustomerMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLCustomerMapper();
			ApiCustomerServerRequestModel model = new ApiCustomerServerRequestModel();
			model.SetProperties("A", "A", "A", "A");
			BOCustomer response = mapper.MapModelToBO(1, model);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLCustomerMapper();
			BOCustomer bo = new BOCustomer();
			bo.SetProperties(1, "A", "A", "A", "A");
			ApiCustomerServerResponseModel response = mapper.MapBOToModel(bo);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLCustomerMapper();
			BOCustomer bo = new BOCustomer();
			bo.SetProperties(1, "A", "A", "A", "A");
			List<ApiCustomerServerResponseModel> response = mapper.MapBOToModel(new List<BOCustomer>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0c1338215862510c89db3572f84e3dd5</Hash>
</Codenesium>*/