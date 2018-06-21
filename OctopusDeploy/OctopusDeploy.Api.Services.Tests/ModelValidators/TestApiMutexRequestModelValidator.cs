using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

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
                        await validator.ValidateUpdateAsync(default(string), new ApiMutexRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }
        }
}

/*<Codenesium>
    <Hash>53145a6a225e4348bbf852a7d7ea1d38</Hash>
</Codenesium>*/