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
	[Trait("Table", "Clasp")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLClaspMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLClaspMapper();
			ApiClaspServerRequestModel model = new ApiClaspServerRequestModel();
			model.SetProperties(1, 1);
			BOClasp response = mapper.MapModelToBO(1, model);

			response.NextChainId.Should().Be(1);
			response.PreviousChainId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLClaspMapper();
			BOClasp bo = new BOClasp();
			bo.SetProperties(1, 1, 1);
			ApiClaspServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.NextChainId.Should().Be(1);
			response.PreviousChainId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLClaspMapper();
			BOClasp bo = new BOClasp();
			bo.SetProperties(1, 1, 1);
			List<ApiClaspServerResponseModel> response = mapper.MapBOToModel(new List<BOClasp>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2321e703a455061119279e5b472a67fc</Hash>
</Codenesium>*/