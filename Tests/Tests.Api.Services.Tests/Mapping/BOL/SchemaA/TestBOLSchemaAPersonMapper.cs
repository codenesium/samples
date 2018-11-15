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
	[Trait("Table", "SchemaAPerson")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSchemaAPersonMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSchemaAPersonMapper();
			ApiSchemaAPersonServerRequestModel model = new ApiSchemaAPersonServerRequestModel();
			model.SetProperties("A");
			BOSchemaAPerson response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSchemaAPersonMapper();
			BOSchemaAPerson bo = new BOSchemaAPerson();
			bo.SetProperties(1, "A");
			ApiSchemaAPersonServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSchemaAPersonMapper();
			BOSchemaAPerson bo = new BOSchemaAPerson();
			bo.SetProperties(1, "A");
			List<ApiSchemaAPersonServerResponseModel> response = mapper.MapBOToModel(new List<BOSchemaAPerson>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>69b30d21b8787bdfa77caed0f31a1c95</Hash>
</Codenesium>*/