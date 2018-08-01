using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ErrorLog")]
	[Trait("Area", "DALMapper")]
	public class TestDALErrorLogMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALErrorLogMapper();
			var bo = new BOErrorLog();
			bo.SetProperties(1, 1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			ErrorLog response = mapper.MapBOToEF(bo);

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
		public void MapEFToBO()
		{
			var mapper = new DALErrorLogMapper();
			ErrorLog entity = new ErrorLog();
			entity.SetProperties(1, 1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			BOErrorLog response = mapper.MapEFToBO(entity);

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
		public void MapEFToBOList()
		{
			var mapper = new DALErrorLogMapper();
			ErrorLog entity = new ErrorLog();
			entity.SetProperties(1, 1, "A", 1, "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			List<BOErrorLog> response = mapper.MapEFToBO(new List<ErrorLog>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a96798edb07805e4f060c6b6c1156e17</Hash>
</Codenesium>*/