using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CustomerCommunication")]
	[Trait("Area", "DALMapper")]
	public class TestDALCustomerCommunicationMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALCustomerCommunicationMapper();
			var bo = new BOCustomerCommunication();
			bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

			CustomerCommunication response = mapper.MapBOToEF(bo);

			response.CustomerId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALCustomerCommunicationMapper();
			CustomerCommunication entity = new CustomerCommunication();
			entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");

			BOCustomerCommunication response = mapper.MapEFToBO(entity);

			response.CustomerId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALCustomerCommunicationMapper();
			CustomerCommunication entity = new CustomerCommunication();
			entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");

			List<BOCustomerCommunication> response = mapper.MapEFToBO(new List<CustomerCommunication>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>aa99d71b7b4673e2199be6425e31db7c</Hash>
</Codenesium>*/