using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Person")]
	[Trait("Area", "DALMapper")]
	public class TestDALPersonMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPersonMapper();
			ApiPersonServerRequestModel model = new ApiPersonServerRequestModel();
			model.SetProperties("A", "A", "A", "A");
			Person response = mapper.MapModelToEntity(1, model);

			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Ssn.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPersonMapper();
			Person item = new Person();
			item.SetProperties(1, "A", "A", "A", "A");
			ApiPersonServerResponseModel response = mapper.MapEntityToModel(item);

			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Ssn.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPersonMapper();
			Person item = new Person();
			item.SetProperties(1, "A", "A", "A", "A");
			List<ApiPersonServerResponseModel> response = mapper.MapEntityToModel(new List<Person>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0548b19d2b13313553e8be298b4cfff9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/