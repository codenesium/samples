using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductModelIllustration")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLProductModelIllustrationMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLProductModelIllustrationMapper();
			ApiProductModelIllustrationRequestModel model = new ApiProductModelIllustrationRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			BOProductModelIllustration response = mapper.MapModelToBO(1, model);

			response.IllustrationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLProductModelIllustrationMapper();
			BOProductModelIllustration bo = new BOProductModelIllustration();
			bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiProductModelIllustrationResponseModel response = mapper.MapBOToModel(bo);

			response.IllustrationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ProductModelID.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLProductModelIllustrationMapper();
			BOProductModelIllustration bo = new BOProductModelIllustration();
			bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			List<ApiProductModelIllustrationResponseModel> response = mapper.MapBOToModel(new List<BOProductModelIllustration>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>fc260ea25b4a0c53b123610acc80b909</Hash>
</Codenesium>*/