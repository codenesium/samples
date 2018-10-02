using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Sysdiagram")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSysdiagramRequestModelValidatorTest
	{
		public ApiSysdiagramRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ISysdiagramRepository> sysdiagramRepository = new Mock<ISysdiagramRepository>();
			sysdiagramRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sysdiagram()));

			var validator = new ApiSysdiagramRequestModelValidator(sysdiagramRepository.Object);
			await validator.ValidateCreateAsync(new ApiSysdiagramRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ISysdiagramRepository> sysdiagramRepository = new Mock<ISysdiagramRepository>();
			sysdiagramRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sysdiagram()));

			var validator = new ApiSysdiagramRequestModelValidator(sysdiagramRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSysdiagramRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ISysdiagramRepository> sysdiagramRepository = new Mock<ISysdiagramRepository>();
			sysdiagramRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sysdiagram()));

			var validator = new ApiSysdiagramRequestModelValidator(sysdiagramRepository.Object);
			await validator.ValidateCreateAsync(new ApiSysdiagramRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ISysdiagramRepository> sysdiagramRepository = new Mock<ISysdiagramRepository>();
			sysdiagramRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sysdiagram()));

			var validator = new ApiSysdiagramRequestModelValidator(sysdiagramRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSysdiagramRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		private async void BeUniqueByPrincipalIdName_Create_Exists()
		{
			Mock<ISysdiagramRepository> sysdiagramRepository = new Mock<ISysdiagramRepository>();
			sysdiagramRepository.Setup(x => x.ByPrincipalIdName(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<Sysdiagram>(new Sysdiagram()));
			var validator = new ApiSysdiagramRequestModelValidator(sysdiagramRepository.Object);

			await validator.ValidateCreateAsync(new ApiSysdiagramRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByPrincipalIdName_Create_Not_Exists()
		{
			Mock<ISysdiagramRepository> sysdiagramRepository = new Mock<ISysdiagramRepository>();
			sysdiagramRepository.Setup(x => x.ByPrincipalIdName(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<Sysdiagram>(null));
			var validator = new ApiSysdiagramRequestModelValidator(sysdiagramRepository.Object);

			await validator.ValidateCreateAsync(new ApiSysdiagramRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByPrincipalIdName_Update_Exists()
		{
			Mock<ISysdiagramRepository> sysdiagramRepository = new Mock<ISysdiagramRepository>();
			sysdiagramRepository.Setup(x => x.ByPrincipalIdName(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<Sysdiagram>(new Sysdiagram()));
			var validator = new ApiSysdiagramRequestModelValidator(sysdiagramRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSysdiagramRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByPrincipalIdName_Update_Not_Exists()
		{
			Mock<ISysdiagramRepository> sysdiagramRepository = new Mock<ISysdiagramRepository>();
			sysdiagramRepository.Setup(x => x.ByPrincipalIdName(It.IsAny<int>(), It.IsAny<string>())).Returns(Task.FromResult<Sysdiagram>(null));
			var validator = new ApiSysdiagramRequestModelValidator(sysdiagramRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSysdiagramRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>7f032625b708bbb812a6294bfeb5552f</Hash>
</Codenesium>*/