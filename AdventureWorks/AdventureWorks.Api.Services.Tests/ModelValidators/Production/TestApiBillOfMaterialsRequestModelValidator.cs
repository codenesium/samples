using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
using Xunit;

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
                        await validator.ValidateUpdateAsync(default(int), new ApiBillOfMaterialsRequestModel());

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
                        await validator.ValidateUpdateAsync(default(int), new ApiBillOfMaterialsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, new string('A', 4));
                }

                [Fact]
                private async void BeUniqueByProductAssemblyIDComponentIDStartDate_Create_Exists()
                {
                        Mock<IBillOfMaterialsRepository> billOfMaterialsRepository = new Mock<IBillOfMaterialsRepository>();
                        billOfMaterialsRepository.Setup(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(Task.FromResult<BillOfMaterials>(new BillOfMaterials()));
                        var validator = new ApiBillOfMaterialsRequestModelValidator(billOfMaterialsRepository.Object);

                        await validator.ValidateCreateAsync(new ApiBillOfMaterialsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ComponentID, 1);
                }

                [Fact]
                private async void BeUniqueByProductAssemblyIDComponentIDStartDate_Create_Not_Exists()
                {
                        Mock<IBillOfMaterialsRepository> billOfMaterialsRepository = new Mock<IBillOfMaterialsRepository>();
                        billOfMaterialsRepository.Setup(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(Task.FromResult<BillOfMaterials>(null));
                        var validator = new ApiBillOfMaterialsRequestModelValidator(billOfMaterialsRepository.Object);

                        await validator.ValidateCreateAsync(new ApiBillOfMaterialsRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ComponentID, 1);
                }

                [Fact]
                private async void BeUniqueByProductAssemblyIDComponentIDStartDate_Update_Exists()
                {
                        Mock<IBillOfMaterialsRepository> billOfMaterialsRepository = new Mock<IBillOfMaterialsRepository>();
                        billOfMaterialsRepository.Setup(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(Task.FromResult<BillOfMaterials>(new BillOfMaterials()));
                        var validator = new ApiBillOfMaterialsRequestModelValidator(billOfMaterialsRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiBillOfMaterialsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ComponentID, 1);
                }

                [Fact]
                private async void BeUniqueByProductAssemblyIDComponentIDStartDate_Update_Not_Exists()
                {
                        Mock<IBillOfMaterialsRepository> billOfMaterialsRepository = new Mock<IBillOfMaterialsRepository>();
                        billOfMaterialsRepository.Setup(x => x.ByProductAssemblyIDComponentIDStartDate(It.IsAny<int?>(), It.IsAny<int>(), It.IsAny<DateTime>())).Returns(Task.FromResult<BillOfMaterials>(null));
                        var validator = new ApiBillOfMaterialsRequestModelValidator(billOfMaterialsRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiBillOfMaterialsRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ComponentID, 1);
                }
        }
}

/*<Codenesium>
    <Hash>b3c754ec66e4d956ceb3f78dbd3c02da</Hash>
</Codenesium>*/