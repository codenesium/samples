using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ErrorLog")]
	[Trait("Area", "DALMapper")]
	public class TestDALErrorLogMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALErrorLogMapper();
			ApiErrorLogServerRequestModel model = new ApiErrorLogServerRequestModel();
			model.SetProperties(1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ErrorLog response = mapper.MapModelToEntity(1, model);

			response.ErrorLine.Should().Be(1);
			response.ErrorMessage.Should().Be("A");
			response.ErrorNumber.Should().Be(1);
			response.ErrorProcedure.Should().Be("A");
			response.ErrorSeverity.Should().Be(1);
			response.ErrorState.Should().Be(1);
			response.ErrorTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.UserName.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALErrorLogMapper();
			ErrorLog item = new ErrorLog();
			item.SetProperties(1, 1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiErrorLogServerResponseModel response = mapper.MapEntityToModel(item);

			response.ErrorLine.Should().Be(1);
			response.ErrorLogID.Should().Be(1);
			response.ErrorMessage.Should().Be("A");
			response.ErrorNumber.Should().Be(1);
			response.ErrorProcedure.Should().Be("A");
			response.ErrorSeverity.Should().Be(1);
			response.ErrorState.Should().Be(1);
			response.ErrorTime.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.UserName.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALErrorLogMapper();
			ErrorLog item = new ErrorLog();
			item.SetProperties(1, 1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiErrorLogServerResponseModel> response = mapper.MapEntityToModel(new List<ErrorLog>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6361a84630f91c29baf8fcb85ba5c9cb</Hash>
</Codenesium>*/