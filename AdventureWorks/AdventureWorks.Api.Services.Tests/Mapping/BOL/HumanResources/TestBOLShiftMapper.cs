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
	[Trait("Table", "Shift")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLShiftMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLShiftMapper();
			ApiShiftServerRequestModel model = new ApiShiftServerRequestModel();
			model.SetProperties(TimeSpan.Parse("01:00:00"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("01:00:00"));
			BOShift response = mapper.MapModelToBO(1, model);

			response.EndTime.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.StartTime.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLShiftMapper();
			BOShift bo = new BOShift();
			bo.SetProperties(1, TimeSpan.Parse("01:00:00"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("01:00:00"));
			ApiShiftServerResponseModel response = mapper.MapBOToModel(bo);

			response.EndTime.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
			response.ShiftID.Should().Be(1);
			response.StartTime.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLShiftMapper();
			BOShift bo = new BOShift();
			bo.SetProperties(1, TimeSpan.Parse("01:00:00"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A", TimeSpan.Parse("01:00:00"));
			List<ApiShiftServerResponseModel> response = mapper.MapBOToModel(new List<BOShift>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2e3799de907cbf1ef4e1680231a17726</Hash>
</Codenesium>*/