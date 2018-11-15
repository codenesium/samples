using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Customer")]
	[Trait("Area", "DALMapper")]
	public class TestDALCustomerMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALCustomerMapper();
			var bo = new BOCustomer();
			bo.SetProperties(1, "A", "A", "A", "A", "A");

			Customer response = mapper.MapBOToEF(bo);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Note.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALCustomerMapper();
			Customer entity = new Customer();
			entity.SetProperties("A", "A", 1, "A", "A", "A");

			BOCustomer response = mapper.MapEFToBO(entity);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Note.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALCustomerMapper();
			Customer entity = new Customer();
			entity.SetProperties("A", "A", 1, "A", "A", "A");

			List<BOCustomer> response = mapper.MapEFToBO(new List<Customer>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>932779644472cb3e60921f863fd98f57</Hash>
</Codenesium>*/