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
		public void MapModelToEntity()
		{
			var mapper = new DALIllustrationMapper();
			ApiIllustrationServerRequestModel model = new ApiIllustrationServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"));
			Illustration response = mapper.MapModelToEntity(1, model);

			response.Diagram.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALIllustrationMapper();
			Illustration item = new Illustration();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiIllustrationServerResponseModel response = mapper.MapEntityToModel(item);

			response.Diagram.Should().Be("A");
			response.IllustrationID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALIllustrationMapper();
			Illustration item = new Illustration();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"));
			List<ApiIllustrationServerResponseModel> response = mapper.MapEntityToModel(new List<Illustration>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ec516183a0dd38eeaa94b8df025ab9f0</Hash>
</Codenesium>*/