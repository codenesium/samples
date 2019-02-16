using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Shift")]
	[Trait("Area", "DALMapper")]
	public class TestDALShiftMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new DALShiftMapper();
			ApiShiftServerRequestModel model = new ApiShiftServerRequestModel();
			model.SetProperties(TimeSpan.Parse("01:00:00"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("01:00:00"));
			Shift response = mapper.MapModelToBO(1, model);

			response.EndTime.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.StartTime.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new DALShiftMapper();
			Shift item = new Shift();
			item.SetProperties(1, TimeSpan.Parse("01:00:00"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("01:00:00"));
			ApiShiftServerResponseModel response = mapper.MapBOToModel(item);

			response.EndTime.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ShiftID.Should().Be(1);
			response.StartTime.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new DALShiftMapper();
			Shift item = new Shift();
			item.SetProperties(1, TimeSpan.Parse("01:00:00"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("01:00:00"));
			List<ApiShiftServerResponseModel> response = mapper.MapBOToModel(new List<Shift>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>490d002ef02aae09a7c73c00d9c69a10</Hash>
</Codenesium>*/