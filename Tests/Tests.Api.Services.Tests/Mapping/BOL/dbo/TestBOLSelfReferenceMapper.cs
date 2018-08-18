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
	[Trait("Table", "SelfReference")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSelfReferenceMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSelfReferenceMapper();
			ApiSelfReferenceRequestModel model = new ApiSelfReferenceRequestModel();
			model.SetProperties(1, 1);
			BOSelfReference response = mapper.MapModelToBO(1, model);

			response.SelfReferenceId.Should().Be(1);
			response.SelfReferenceId2.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSelfReferenceMapper();
			BOSelfReference bo = new BOSelfReference();
			bo.SetProperties(1, 1, 1);
			ApiSelfReferenceResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.SelfReferenceId.Should().Be(1);
			response.SelfReferenceId2.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSelfReferenceMapper();
			BOSelfReference bo = new BOSelfReference();
			bo.SetProperties(1, 1, 1);
			List<ApiSelfReferenceResponseModel> response = mapper.MapBOToModel(new List<BOSelfReference>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>45b8e855e6a4152d4798076eace334fc</Hash>
</Codenesium>*/