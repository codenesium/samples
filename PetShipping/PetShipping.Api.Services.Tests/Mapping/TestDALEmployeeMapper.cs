using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Employee")]
	[Trait("Area", "DALMapper")]
	public class TestDALEmployeeMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALEmployeeMapper();
			ApiEmployeeServerRequestModel model = new ApiEmployeeServerRequestModel();
			model.SetProperties("A", true, true, "A");
			Employee response = mapper.MapModelToEntity(1, model);

			response.FirstName.Should().Be("A");
			response.IsSalesPerson.Should().Be(true);
			response.IsShipper.Should().Be(true);
			response.LastName.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALEmployeeMapper();
			Employee item = new Employee();
			item.SetProperties(1, "A", true, true, "A");
			ApiEmployeeServerResponseModel response = mapper.MapEntityToModel(item);

			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.IsSalesPerson.Should().Be(true);
			response.IsShipper.Should().Be(true);
			response.LastName.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALEmployeeMapper();
			Employee item = new Employee();
			item.SetProperties(1, "A", true, true, "A");
			List<ApiEmployeeServerResponseModel> response = mapper.MapEntityToModel(new List<Employee>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>84354e1ce3a0dc5c21d98c6b6b361e8a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/