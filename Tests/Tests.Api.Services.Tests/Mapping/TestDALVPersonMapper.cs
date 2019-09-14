using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VPerson")]
	[Trait("Area", "DALMapper")]
	public class TestDALVPersonMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALVPersonMapper();
			ApiVPersonServerRequestModel model = new ApiVPersonServerRequestModel();
			model.SetProperties("A");
			VPerson response = mapper.MapModelToEntity(1, model);

			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALVPersonMapper();
			VPerson item = new VPerson();
			item.SetProperties(1, "A");
			ApiVPersonServerResponseModel response = mapper.MapEntityToModel(item);

			response.PersonId.Should().Be(1);
			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALVPersonMapper();
			VPerson item = new VPerson();
			item.SetProperties(1, "A");
			List<ApiVPersonServerResponseModel> response = mapper.MapEntityToModel(new List<VPerson>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b3c7332f98b2a0a9d8e425287a3d2482</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/