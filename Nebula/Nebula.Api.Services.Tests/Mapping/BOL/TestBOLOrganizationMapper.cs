using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Organization")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLOrganizationMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLOrganizationMapper();
			ApiOrganizationServerRequestModel model = new ApiOrganizationServerRequestModel();
			model.SetProperties("A");
			BOOrganization response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLOrganizationMapper();
			BOOrganization bo = new BOOrganization();
			bo.SetProperties(1, "A");
			ApiOrganizationServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLOrganizationMapper();
			BOOrganization bo = new BOOrganization();
			bo.SetProperties(1, "A");
			List<ApiOrganizationServerResponseModel> response = mapper.MapBOToModel(new List<BOOrganization>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8012f149cfa445f04def39aab7f77c28</Hash>
</Codenesium>*/