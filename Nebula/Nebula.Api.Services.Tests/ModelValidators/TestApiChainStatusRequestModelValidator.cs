using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System.Linq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ChainStatus")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiChainStatusRequestModelValidatorTest
        {
                public ApiChainStatusRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
                        chainStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));

                        var validator = new ApiChainStatusRequestModelValidator(chainStatusRepository.Object);

                        await validator.ValidateCreateAsync(new ApiChainStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
                        chainStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));

                        var validator = new ApiChainStatusRequestModelValidator(chainStatusRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiChainStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
                        chainStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));

                        var validator = new ApiChainStatusRequestModelValidator(chainStatusRepository.Object);

                        await validator.ValidateCreateAsync(new ApiChainStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
                        chainStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));

                        var validator = new ApiChainStatusRequestModelValidator(chainStatusRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiChainStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IChainStatusRepository> chainStatusRepository = new Mock<IChainStatusRepository>();
                        chainStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new ChainStatus()));

                        var validator = new ApiChainStatusRequestModelValidator(chainStatusRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>4198aed8a16ff90de6be9541a4cca055</Hash>
</Codenesium>*/