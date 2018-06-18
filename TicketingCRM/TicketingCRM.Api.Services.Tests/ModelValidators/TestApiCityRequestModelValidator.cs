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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "City")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiCityRequestModelValidatorTest
        {
                public ApiCityRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
                        cityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new City()));

                        var validator = new ApiCityRequestModelValidator(cityRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCityRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
                        cityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new City()));

                        var validator = new ApiCityRequestModelValidator(cityRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCityRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
                        cityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new City()));

                        var validator = new ApiCityRequestModelValidator(cityRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCityRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
                        cityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new City()));

                        var validator = new ApiCityRequestModelValidator(cityRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCityRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
                        cityRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new City()));

                        var validator = new ApiCityRequestModelValidator(cityRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ProvinceId_Create_Valid_Reference()
                {
                        Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
                        cityRepository.Setup(x => x.GetProvince(It.IsAny<int>())).Returns(Task.FromResult<Province>(new Province()));

                        var validator = new ApiCityRequestModelValidator(cityRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCityRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ProvinceId, 1);
                }

                [Fact]
                public async void ProvinceId_Create_Invalid_Reference()
                {
                        Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
                        cityRepository.Setup(x => x.GetProvince(It.IsAny<int>())).Returns(Task.FromResult<Province>(null));

                        var validator = new ApiCityRequestModelValidator(cityRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCityRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProvinceId, 1);
                }

                [Fact]
                public async void ProvinceId_Update_Valid_Reference()
                {
                        Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
                        cityRepository.Setup(x => x.GetProvince(It.IsAny<int>())).Returns(Task.FromResult<Province>(new Province()));

                        var validator = new ApiCityRequestModelValidator(cityRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCityRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ProvinceId, 1);
                }

                [Fact]
                public async void ProvinceId_Update_Invalid_Reference()
                {
                        Mock<ICityRepository> cityRepository = new Mock<ICityRepository>();
                        cityRepository.Setup(x => x.GetProvince(It.IsAny<int>())).Returns(Task.FromResult<Province>(null));

                        var validator = new ApiCityRequestModelValidator(cityRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCityRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProvinceId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>335ae5c733e6284da13fa931d6203b9a</Hash>
</Codenesium>*/