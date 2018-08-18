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
	[Trait("Table", "TimestampCheck")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTimestampCheckRequestModelValidatorTest
	{
		public ApiTimestampCheckRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ITimestampCheckRepository> timestampCheckRepository = new Mock<ITimestampCheckRepository>();
			timestampCheckRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TimestampCheck()));

			var validator = new ApiTimestampCheckRequestModelValidator(timestampCheckRepository.Object);
			await validator.ValidateCreateAsync(new ApiTimestampCheckRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ITimestampCheckRepository> timestampCheckRepository = new Mock<ITimestampCheckRepository>();
			timestampCheckRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TimestampCheck()));

			var validator = new ApiTimestampCheckRequestModelValidator(timestampCheckRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTimestampCheckRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}
	}
}

/*<Codenesium>
    <Hash>3a50e2e6a0d7e85519059aea4f376b3c</Hash>
</Codenesium>*/