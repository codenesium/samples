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
			ApiVPersonServerRequestModel model = new ApiVPersonServerRequestModel();
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
			ApiVPersonServerResponseModel response = mapper.MapBOToModel(bo);

			response.PersonId.Should().Be(1);
			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLVPersonMapper();
			BOVPerson bo = new BOVPerson();
			bo.SetProperties(1, "A");
			List<ApiVPersonServerResponseModel> response = mapper.MapBOToModel(new List<BOVPerson>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>62848cbed93d8b9cfcf1eed1916f8fe2</Hash>
</Codenesium>*/