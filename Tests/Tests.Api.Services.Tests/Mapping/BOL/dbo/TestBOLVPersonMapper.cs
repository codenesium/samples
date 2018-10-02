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
	[Trait("Table", "VPerson")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLVPersonMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLVPersonMapper();
			ApiVPersonRequestModel model = new ApiVPersonRequestModel();
			model.SetProperties("A");
			BOVPerson response = mapper.MapModelToBO(1, model);

			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLVPersonMapper();
			BOVPerson bo = new BOVPerson();
			bo.SetProperties(1, "A");
			ApiVPersonResponseModel response = mapper.MapBOToModel(bo);

			response.PersonId.Should().Be(1);
			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLVPersonMapper();
			BOVPerson bo = new BOVPerson();
			bo.SetProperties(1, "A");
			List<ApiVPersonResponseModel> response = mapper.MapBOToModel(new List<BOVPerson>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>959430282bc025f5c779edc34a58317c</Hash>
</Codenesium>*/