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
			ApiSchemaAPersonRequestModel model = new ApiSchemaAPersonRequestModel();
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
			ApiSchemaAPersonResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSchemaAPersonMapper();
			BOSchemaAPerson bo = new BOSchemaAPerson();
			bo.SetProperties(1, "A");
			List<ApiSchemaAPersonResponseModel> response = mapper.MapBOToModel(new List<BOSchemaAPerson>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e85e4f6ac29a34d6a78b94e4c1661403</Hash>
</Codenesium>*/