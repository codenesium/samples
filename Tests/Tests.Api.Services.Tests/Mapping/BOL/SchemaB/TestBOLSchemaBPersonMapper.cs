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
	[Trait("Table", "SchemaBPerson")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSchemaBPersonMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSchemaBPersonMapper();
			ApiSchemaBPersonServerRequestModel model = new ApiSchemaBPersonServerRequestModel();
			model.SetProperties("A");
			BOSchemaBPerson response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSchemaBPersonMapper();
			BOSchemaBPerson bo = new BOSchemaBPerson();
			bo.SetProperties(1, "A");
			ApiSchemaBPersonServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSchemaBPersonMapper();
			BOSchemaBPerson bo = new BOSchemaBPerson();
			bo.SetProperties(1, "A");
			List<ApiSchemaBPersonServerResponseModel> response = mapper.MapBOToModel(new List<BOSchemaBPerson>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5a0d58eae8f6f34170507bcdc962b9f6</Hash>
</Codenesium>*/