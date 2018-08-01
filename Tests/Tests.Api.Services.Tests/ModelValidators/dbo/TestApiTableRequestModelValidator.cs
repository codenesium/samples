using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Table")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTableRequestModelValidatorTest
	{
		public ApiTableRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ITableRepository> tableRepository = new Mock<ITableRepository>();
			tableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Table()));

			var validator = new ApiTableRequestModelValidator(tableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ITableRepository> tableRepository = new Mock<ITableRepository>();
			tableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Table()));

			var validator = new ApiTableRequestModelValidator(tableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ITableRepository> tableRepository = new Mock<ITableRepository>();
			tableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Table()));

			var validator = new ApiTableRequestModelValidator(tableRepository.Object);
			await validator.ValidateCreateAsync(new ApiTableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ITableRepository> tableRepository = new Mock<ITableRepository>();
			tableRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Table()));

			var validator = new ApiTableRequestModelValidator(tableRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTableRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>2648ff19cbcbe7fd7d9da014ee05e2b5</Hash>
</Codenesium>*/