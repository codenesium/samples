using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Person")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPersonMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPersonMapper();
			ApiPersonServerRequestModel model = new ApiPersonServerRequestModel();
			model.SetProperties("A");
			BOPerson response = mapper.MapModelToBO(1, model);

			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPersonMapper();
			BOPerson bo = new BOPerson();
			bo.SetProperties(1, "A");
			ApiPersonServerResponseModel response = mapper.MapBOToModel(bo);

			response.PersonId.Should().Be(1);
			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPersonMapper();
			BOPerson bo = new BOPerson();
			bo.SetProperties(1, "A");
			List<ApiPersonServerResponseModel> response = mapper.MapBOToModel(new List<BOPerson>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8741d40093b7dc700fab6cf3ba4c6c4b</Hash>
</Codenesium>*/