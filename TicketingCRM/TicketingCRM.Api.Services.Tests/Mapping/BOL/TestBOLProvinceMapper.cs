using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Province")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLProvinceMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLProvinceMapper();
			ApiProvinceServerRequestModel model = new ApiProvinceServerRequestModel();
			model.SetProperties(1, "A");
			BOProvince response = mapper.MapModelToBO(1, model);

			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLProvinceMapper();
			BOProvince bo = new BOProvince();
			bo.SetProperties(1, 1, "A");
			ApiProvinceServerResponseModel response = mapper.MapBOToModel(bo);

			response.CountryId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLProvinceMapper();
			BOProvince bo = new BOProvince();
			bo.SetProperties(1, 1, "A");
			List<ApiProvinceServerResponseModel> response = mapper.MapBOToModel(new List<BOProvince>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>bcc4290786346f78b027c461efb64a1f</Hash>
</Codenesium>*/