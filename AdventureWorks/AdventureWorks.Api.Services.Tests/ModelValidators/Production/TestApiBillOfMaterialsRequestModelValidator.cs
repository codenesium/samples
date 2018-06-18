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
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "BillOfMaterials")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiBillOfMaterialsRequestModelValidatorTest
        {
                public ApiBillOfMaterialsRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void UnitMeasureCode_Create_null()
                {
                        Mock<IBillOfMaterialsRepository> billOfMaterialsRepository = new Mock<IBillOfMaterialsRepository>();
                        billOfMaterialsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterials()));

                        var validator = new ApiBillOfMaterialsRequestModelValidator(billOfMaterialsRepository.Object);

                        await validator.ValidateCreateAsync(new ApiBillOfMaterialsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, null as string);
                }

                [Fact]
                public async void UnitMeasureCode_Update_null()
                {
                        Mock<IBillOfMaterialsRepository> billOfMaterialsRepository = new Mock<IBillOfMaterialsRepository>();
                        billOfMaterialsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterials()));

                        var validator = new ApiBillOfMaterialsRequestModelValidator(billOfMaterialsRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiBillOfMaterialsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, null as string);
                }

                [Fact]
                public async void UnitMeasureCode_Create_length()
                {
                        Mock<IBillOfMaterialsRepository> billOfMaterialsRepository = new Mock<IBillOfMaterialsRepository>();
                        billOfMaterialsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterials()));

                        var validator = new ApiBillOfMaterialsRequestModelValidator(billOfMaterialsRepository.Object);

                        await validator.ValidateCreateAsync(new ApiBillOfMaterialsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, new string('A', 4));
                }

                [Fact]
                public async void UnitMeasureCode_Update_length()
                {
                        Mock<IBillOfMaterialsRepository> billOfMaterialsRepository = new Mock<IBillOfMaterialsRepository>();
                        billOfMaterialsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterials()));

                        var validator = new ApiBillOfMaterialsRequestModelValidator(billOfMaterialsRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiBillOfMaterialsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, new string('A', 4));
                }

                [Fact]
                public async void UnitMeasureCode_Delete()
                {
                        Mock<IBillOfMaterialsRepository> billOfMaterialsRepository = new Mock<IBillOfMaterialsRepository>();
                        billOfMaterialsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterials()));

                        var validator = new ApiBillOfMaterialsRequestModelValidator(billOfMaterialsRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByProductAssemblyIDComponentIDStartDate_Create_Exists()
                {
                        Mock<IBillOfMaterialsRepository> billOfMaterialsRepository = new Mock<IBillOfMaterialsRepository>();
                        billOfMaterialsRepository.Setup(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<Nullable<int>>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(Task.FromResult<BillOfMaterials>(new BillOfMaterials()));
                        var validator = new ApiBillOfMaterialsRequestModelValidator(billOfMaterialsRepository.Object);

                        await validator.ValidateCreateAsync(new ApiBillOfMaterialsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ComponentID, 1);
                }

                [Fact]
                private async void BeUniqueByProductAssemblyIDComponentIDStartDate_Create_Not_Exists()
                {
                        Mock<IBillOfMaterialsRepository> billOfMaterialsRepository = new Mock<IBillOfMaterialsRepository>();
                        billOfMaterialsRepository.Setup(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<Nullable<int>>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(Task.FromResult<BillOfMaterials>(null));
                        var validator = new ApiBillOfMaterialsRequestModelValidator(billOfMaterialsRepository.Object);

                        await validator.ValidateCreateAsync(new ApiBillOfMaterialsRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ComponentID, 1);
                }

                [Fact]
                private async void BeUniqueByProductAssemblyIDComponentIDStartDate_Update_Exists()
                {
                        Mock<IBillOfMaterialsRepository> billOfMaterialsRepository = new Mock<IBillOfMaterialsRepository>();
                        billOfMaterialsRepository.Setup(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<Nullable<int>>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(Task.FromResult<BillOfMaterials>(new BillOfMaterials()));
                        var validator = new ApiBillOfMaterialsRequestModelValidator(billOfMaterialsRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiBillOfMaterialsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ComponentID, 1);
                }

                [Fact]
                private async void BeUniqueByProductAssemblyIDComponentIDStartDate_Update_Not_Exists()
                {
                        Mock<IBillOfMaterialsRepository> billOfMaterialsRepository = new Mock<IBillOfMaterialsRepository>();
                        billOfMaterialsRepository.Setup(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<Nullable<int>>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(Task.FromResult<BillOfMaterials>(null));
                        var validator = new ApiBillOfMaterialsRequestModelValidator(billOfMaterialsRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiBillOfMaterialsRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ComponentID, 1);
                }
        }
}

/*<Codenesium>
    <Hash>64f4ede080852862317b63eb16c73b7a</Hash>
</Codenesium>*/