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
	[Trait("Table", "Sysdiagram")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSysdiagramMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSysdiagramMapper();
			ApiSysdiagramRequestModel model = new ApiSysdiagramRequestModel();
			model.SetProperties(BitConverter.GetBytes(1), "A", 1, 1);
			BOSysdiagram response = mapper.MapModelToBO(1, model);

			response.Definition.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Name.Should().Be("A");
			response.PrincipalId.Should().Be(1);
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSysdiagramMapper();
			BOSysdiagram bo = new BOSysdiagram();
			bo.SetProperties(1, BitConverter.GetBytes(1), "A", 1, 1);
			ApiSysdiagramResponseModel response = mapper.MapBOToModel(bo);

			response.Definition.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.DiagramId.Should().Be(1);
			response.Name.Should().Be("A");
			response.PrincipalId.Should().Be(1);
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSysdiagramMapper();
			BOSysdiagram bo = new BOSysdiagram();
			bo.SetProperties(1, BitConverter.GetBytes(1), "A", 1, 1);
			List<ApiSysdiagramResponseModel> response = mapper.MapBOToModel(new List<BOSysdiagram>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>049cdf2ba43fc52a1231a6700dfd16d7</Hash>
</Codenesium>*/