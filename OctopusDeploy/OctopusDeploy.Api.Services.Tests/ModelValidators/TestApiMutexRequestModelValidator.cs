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
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Mutex")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiMutexRequestModelValidatorTest
        {
                public ApiMutexRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IMutexRepository> mutexRepository = new Mock<IMutexRepository>();
                        mutexRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Mutex()));

                        var validator = new ApiMutexRequestModelValidator(mutexRepository.Object);

                        await validator.ValidateCreateAsync(new ApiMutexRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IMutexRepository> mutexRepository = new Mock<IMutexRepository>();
                        mutexRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Mutex()));

                        var validator = new ApiMutexRequestModelValidator(mutexRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiMutexRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }
        }
}

/*<Codenesium>
    <Hash>c90f720fe8a8d0d06abef9c3c2958271</Hash>
</Codenesium>*/