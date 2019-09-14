using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PersonType")]
	[Trait("Area", "DALMapper")]
	public class TestDALPersonTypeMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPersonTypeMapper();
			ApiPersonTypeServerRequestModel model = new ApiPersonTypeServerRequestModel();
			model.SetProperties("A");
			PersonType response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPersonTypeMapper();
			PersonType item = new PersonType();
			item.SetProperties(1, "A");
			ApiPersonTypeServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPersonTypeMapper();
			PersonType item = new PersonType();
			item.SetProperties(1, "A");
			List<ApiPersonTypeServerResponseModel> response = mapper.MapEntityToModel(new List<PersonType>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f565af7bbfc97c187b4ed343ed279cc3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/