using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services
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
			model.SetProperties("A");
			Person response = mapper.MapModelToEntity(1, model);

			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPersonMapper();
			Person item = new Person();
			item.SetProperties(1, "A");
			ApiPersonServerResponseModel response = mapper.MapEntityToModel(item);

			response.PersonId.Should().Be(1);
			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPersonMapper();
			Person item = new Person();
			item.SetProperties(1, "A");
			List<ApiPersonServerResponseModel> response = mapper.MapEntityToModel(new List<Person>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>23a939603366905970774e85d5fd9687</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/