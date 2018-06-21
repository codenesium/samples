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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Province")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiProvinceRequestModelValidatorTest
        {
                public ApiProvinceRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void CountryId_Create_Valid_Reference()
                {
                        Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
                        provinceRepository.Setup(x => x.GetCountry(It.IsAny<int>())).Returns(Task.FromResult<Country>(new Country()));

                        var validator = new ApiProvinceRequestModelValidator(provinceRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProvinceRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CountryId, 1);
                }

                [Fact]
                public async void CountryId_Create_Invalid_Reference()
                {
                        Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
                        provinceRepository.Setup(x => x.GetCountry(It.IsAny<int>())).Returns(Task.FromResult<Country>(null));

                        var validator = new ApiProvinceRequestModelValidator(provinceRepository.Object);

                        await validator.ValidateCreateAsync(new ApiProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryId, 1);
                }

                [Fact]
                public async void CountryId_Update_Valid_Reference()
                {
                        Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
                        provinceRepository.Setup(x => x.GetCountry(It.IsAny<int>())).Returns(Task.FromResult<Country>(new Country()));

                        var validator = new ApiProvinceRequestModelValidator(provinceRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiProvinceRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CountryId, 1);
                }

                [Fact]
                public async void CountryId_Update_Invalid_Reference()
                {
                        Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
                        provinceRepository.Setup(x => x.GetCountry(It.IsAny<int>())).Returns(Task.FromResult<Country>(null));

                        var validator = new ApiProvinceRequestModelValidator(provinceRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryId, 1);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
                        provinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Province()));

                        var validator = new ApiProvinceRequestModelValidator(provinceRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
                        provinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Province()));

                        var validator = new ApiProvinceRequestModelValidator(provinceRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
                        provinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Province()));

                        var validator = new ApiProvinceRequestModelValidator(provinceRepository.Object);
                        await validator.ValidateCreateAsync(new ApiProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
                        provinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Province()));

                        var validator = new ApiProvinceRequestModelValidator(provinceRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiProvinceRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IProvinceRepository> provinceRepository = new Mock<IProvinceRepository>();
                        provinceRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Province()));

                        var validator = new ApiProvinceRequestModelValidator(provinceRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>b76e5e0dbc5a77908a251ab198850e94</Hash>
</Codenesium>*/