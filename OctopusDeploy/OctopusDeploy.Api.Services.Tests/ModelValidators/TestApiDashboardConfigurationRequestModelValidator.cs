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
        [Trait("Table", "DashboardConfiguration")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiDashboardConfigurationRequestModelValidatorTest
        {
                public ApiDashboardConfigurationRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void IncludedEnvironmentIds_Create_null()
                {
                        Mock<IDashboardConfigurationRepository> dashboardConfigurationRepository = new Mock<IDashboardConfigurationRepository>();
                        dashboardConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DashboardConfiguration()));

                        var validator = new ApiDashboardConfigurationRequestModelValidator(dashboardConfigurationRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDashboardConfigurationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.IncludedEnvironmentIds, null as string);
                }

                [Fact]
                public async void IncludedEnvironmentIds_Update_null()
                {
                        Mock<IDashboardConfigurationRepository> dashboardConfigurationRepository = new Mock<IDashboardConfigurationRepository>();
                        dashboardConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DashboardConfiguration()));

                        var validator = new ApiDashboardConfigurationRequestModelValidator(dashboardConfigurationRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDashboardConfigurationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.IncludedEnvironmentIds, null as string);
                }

                [Fact]
                public async void IncludedProjectIds_Create_null()
                {
                        Mock<IDashboardConfigurationRepository> dashboardConfigurationRepository = new Mock<IDashboardConfigurationRepository>();
                        dashboardConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DashboardConfiguration()));

                        var validator = new ApiDashboardConfigurationRequestModelValidator(dashboardConfigurationRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDashboardConfigurationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.IncludedProjectIds, null as string);
                }

                [Fact]
                public async void IncludedProjectIds_Update_null()
                {
                        Mock<IDashboardConfigurationRepository> dashboardConfigurationRepository = new Mock<IDashboardConfigurationRepository>();
                        dashboardConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DashboardConfiguration()));

                        var validator = new ApiDashboardConfigurationRequestModelValidator(dashboardConfigurationRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDashboardConfigurationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.IncludedProjectIds, null as string);
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IDashboardConfigurationRepository> dashboardConfigurationRepository = new Mock<IDashboardConfigurationRepository>();
                        dashboardConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DashboardConfiguration()));

                        var validator = new ApiDashboardConfigurationRequestModelValidator(dashboardConfigurationRepository.Object);
                        await validator.ValidateCreateAsync(new ApiDashboardConfigurationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IDashboardConfigurationRepository> dashboardConfigurationRepository = new Mock<IDashboardConfigurationRepository>();
                        dashboardConfigurationRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new DashboardConfiguration()));

                        var validator = new ApiDashboardConfigurationRequestModelValidator(dashboardConfigurationRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiDashboardConfigurationRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }
        }
}

/*<Codenesium>
    <Hash>09c3789039555a29169a0bbc23f942a6</Hash>
</Codenesium>*/