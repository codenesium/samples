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
	[Trait("Table", "CompositePrimaryKey")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLCompositePrimaryKeyMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLCompositePrimaryKeyMapper();
			ApiCompositePrimaryKeyServerRequestModel model = new ApiCompositePrimaryKeyServerRequestModel();
			model.SetProperties(1);
			BOCompositePrimaryKey response = mapper.MapModelToBO(1, model);

			response.Id2.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLCompositePrimaryKeyMapper();
			BOCompositePrimaryKey bo = new BOCompositePrimaryKey();
			bo.SetProperties(1, 1);
			ApiCompositePrimaryKeyServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Id2.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLCompositePrimaryKeyMapper();
			BOCompositePrimaryKey bo = new BOCompositePrimaryKey();
			bo.SetProperties(1, 1);
			List<ApiCompositePrimaryKeyServerResponseModel> response = mapper.MapBOToModel(new List<BOCompositePrimaryKey>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5817eaad2caae979c66a17934293838e</Hash>
</Codenesium>*/