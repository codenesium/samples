using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Organization")]
	[Trait("Area", "DALMapper")]
	public class TestDALOrganizationMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALOrganizationMapper();
			ApiOrganizationServerRequestModel model = new ApiOrganizationServerRequestModel();
			model.SetProperties("A");
			Organization response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALOrganizationMapper();
			Organization item = new Organization();
			item.SetProperties(1, "A");
			ApiOrganizationServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALOrganizationMapper();
			Organization item = new Organization();
			item.SetProperties(1, "A");
			List<ApiOrganizationServerResponseModel> response = mapper.MapEntityToModel(new List<Organization>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>81b83b0625debe083cd96911fe499bb2</Hash>
</Codenesium>*/