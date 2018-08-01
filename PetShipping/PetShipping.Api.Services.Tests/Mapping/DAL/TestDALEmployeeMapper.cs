using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Employee")]
	[Trait("Area", "DALMapper")]
	public class TestDALEmployeeMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALEmployeeMapper();
			var bo = new BOEmployee();
			bo.SetProperties(1, "A", true, true, "A");

			Employee response = mapper.MapBOToEF(bo);

			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.IsSalesPerson.Should().Be(true);
			response.IsShipper.Should().Be(true);
			response.LastName.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALEmployeeMapper();
			Employee entity = new Employee();
			entity.SetProperties("A", 1, true, true, "A");

			BOEmployee response = mapper.MapEFToBO(entity);

			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.IsSalesPerson.Should().Be(true);
			response.IsShipper.Should().Be(true);
			response.LastName.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALEmployeeMapper();
			Employee entity = new Employee();
			entity.SetProperties("A", 1, true, true, "A");

			List<BOEmployee> response = mapper.MapEFToBO(new List<Employee>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>498afbb6daa92113e2b88a204c507892</Hash>
</Codenesium>*/