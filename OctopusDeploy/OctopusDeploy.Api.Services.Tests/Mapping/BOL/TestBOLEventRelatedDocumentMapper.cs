using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventRelatedDocument")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLEventRelatedDocumentMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLEventRelatedDocumentMapper();
			ApiEventRelatedDocumentRequestModel model = new ApiEventRelatedDocumentRequestModel();
			model.SetProperties("A", "A");
			BOEventRelatedDocument response = mapper.MapModelToBO(1, model);

			response.EventId.Should().Be("A");
			response.RelatedDocumentId.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLEventRelatedDocumentMapper();
			BOEventRelatedDocument bo = new BOEventRelatedDocument();
			bo.SetProperties(1, "A", "A");
			ApiEventRelatedDocumentResponseModel response = mapper.MapBOToModel(bo);

			response.EventId.Should().Be("A");
			response.Id.Should().Be(1);
			response.RelatedDocumentId.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLEventRelatedDocumentMapper();
			BOEventRelatedDocument bo = new BOEventRelatedDocument();
			bo.SetProperties(1, "A", "A");
			List<ApiEventRelatedDocumentResponseModel> response = mapper.MapBOToModel(new List<BOEventRelatedDocument>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3e60e291e96002edcb07d9056c67a09f</Hash>
</Codenesium>*/