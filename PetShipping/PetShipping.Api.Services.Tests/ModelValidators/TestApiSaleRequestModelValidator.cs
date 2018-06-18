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
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Sale")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSaleRequestModelValidatorTest
        {
                public ApiSaleRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void ClientId_Create_Valid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(new Client()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ClientId, 1);
                }

                [Fact]
                public async void ClientId_Create_Invalid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(null));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ClientId, 1);
                }

                [Fact]
                public async void ClientId_Update_Valid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(new Client()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ClientId, 1);
                }

                [Fact]
                public async void ClientId_Update_Invalid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetClient(It.IsAny<int>())).Returns(Task.FromResult<Client>(null));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ClientId, 1);
                }

                [Fact]
                public async void Note_Create_null()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Note, null as string);
                }

                [Fact]
                public async void Note_Update_null()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Note, null as string);
                }

                [Fact]
                public async void PetId_Create_Valid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetPet(It.IsAny<int>())).Returns(Task.FromResult<Pet>(new Pet()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PetId, 1);
                }

                [Fact]
                public async void PetId_Create_Invalid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetPet(It.IsAny<int>())).Returns(Task.FromResult<Pet>(null));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PetId, 1);
                }

                [Fact]
                public async void PetId_Update_Valid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetPet(It.IsAny<int>())).Returns(Task.FromResult<Pet>(new Pet()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.PetId, 1);
                }

                [Fact]
                public async void PetId_Update_Invalid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetPet(It.IsAny<int>())).Returns(Task.FromResult<Pet>(null));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PetId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>3970310176785d1beb12069ec2862a07</Hash>
</Codenesium>*/