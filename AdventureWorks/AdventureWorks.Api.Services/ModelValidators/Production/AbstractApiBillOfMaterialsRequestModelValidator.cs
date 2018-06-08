using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services

{
        public abstract class AbstractApiBillOfMaterialsRequestModelValidator: AbstractValidator<ApiBillOfMaterialsRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiBillOfMaterialsRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiBillOfMaterialsRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IBillOfMaterialsRepository BillOfMaterialsRepository { get; set; }
                public virtual void BOMLevelRules()
                {
                        this.RuleFor(x => x.BOMLevel).NotNull();
                }

                public virtual void ComponentIDRules()
                {
                        this.RuleFor(x => x.ComponentID).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetProductAssemblyIDComponentIDStartDate).When(x => x ?.ComponentID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBillOfMaterialsRequestModel.ComponentID));
                }

                public virtual void EndDateRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                        this.RuleFor(x => x.ModifiedDate).NotNull();
                }

                public virtual void PerAssemblyQtyRules()
                {
                        this.RuleFor(x => x.PerAssemblyQty).NotNull();
                }

                public virtual void ProductAssemblyIDRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetProductAssemblyIDComponentIDStartDate).When(x => x ?.ProductAssemblyID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBillOfMaterialsRequestModel.ProductAssemblyID));
                }

                public virtual void StartDateRules()
                {
                        this.RuleFor(x => x.StartDate).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetProductAssemblyIDComponentIDStartDate).When(x => x ?.StartDate != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBillOfMaterialsRequestModel.StartDate));
                }

                public virtual void UnitMeasureCodeRules()
                {
                        this.RuleFor(x => x.UnitMeasureCode).NotNull();
                        this.RuleFor(x => x.UnitMeasureCode).Length(0, 3);
                }

                private async Task<bool> BeUniqueGetProductAssemblyIDComponentIDStartDate(ApiBillOfMaterialsRequestModel model,  CancellationToken cancellationToken)
                {
                        BillOfMaterials record = await this.BillOfMaterialsRepository.GetProductAssemblyIDComponentIDStartDate(model.ProductAssemblyID, model.ComponentID, model.StartDate);

                        if (record == null || record.BillOfMaterialsID == this.existingRecordId)
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>36b362af7e587ee89d01a89be9588f43</Hash>
</Codenesium>*/