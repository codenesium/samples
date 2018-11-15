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
	[Trait("Table", "Employee")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLEmployeeMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLEmployeeMapper();
			ApiEmployeeServerRequestModel model = new ApiEmployeeServerRequestModel();
			model.SetProperties("A", true, true, "A");
			BOEmployee response = mapper.MapModelToBO(1, model);

			response.FirstName.Should().Be("A");
			response.IsSalesPerson.Should().Be(true);
			response.IsShipper.Should().Be(true);
			response.LastName.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLEmployeeMapper();
			BOEmployee bo = new BOEmployee();
			bo.SetProperties(1, "A", true, true, "A");
			ApiEmployeeServerResponseModel response = mapper.MapBOToModel(bo);

			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.IsSalesPerson.Should().Be(true);
			response.IsShipper.Should().Be(true);
			response.LastName.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLEmployeeMapper();
			BOEmployee bo = new BOEmployee();
			bo.SetProperties(1, "A", true, true, "A");
			List<ApiEmployeeServerResponseModel> response = mapper.MapBOToModel(new List<BOEmployee>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>da31adff86f19e5e1895004fa8629c8e</Hash>
</Codenesium>*/