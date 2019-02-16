using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Illustration")]
	[Trait("Area", "DALMapper")]
	public class TestDALIllustrationMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new DALIllustrationMapper();
			ApiIllustrationServerRequestModel model = new ApiIllustrationServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"));
			Illustration response = mapper.MapModelToBO(1, model);

			response.Diagram.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new DALIllustrationMapper();
			Illustration item = new Illustration();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiIllustrationServerResponseModel response = mapper.MapBOToModel(item);

			response.Diagram.Should().Be("A");
			response.IllustrationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new DALIllustrationMapper();
			Illustration item = new Illustration();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"));
			List<ApiIllustrationServerResponseModel> response = mapper.MapBOToModel(new List<Illustration>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c898add701635cbc8601fd7ab6999961</Hash>
</Codenesium>*/