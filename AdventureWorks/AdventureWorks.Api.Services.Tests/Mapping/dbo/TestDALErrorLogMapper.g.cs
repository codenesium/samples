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
		public void MapModelToBO()
		{
			var mapper = new DALErrorLogMapper();
			ApiErrorLogServerRequestModel model = new ApiErrorLogServerRequestModel();
			model.SetProperties(1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ErrorLog response = mapper.MapModelToBO(1, model);

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
		public void MapBOToModel()
		{
			var mapper = new DALErrorLogMapper();
			ErrorLog item = new ErrorLog();
			item.SetProperties(1, 1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiErrorLogServerResponseModel response = mapper.MapBOToModel(item);

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
		public void MapBOToModelList()
		{
			var mapper = new DALErrorLogMapper();
			ErrorLog item = new ErrorLog();
			item.SetProperties(1, 1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiErrorLogServerResponseModel> response = mapper.MapBOToModel(new List<ErrorLog>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6966a1e870f505f2544d05a0be113859</Hash>
</Codenesium>*/