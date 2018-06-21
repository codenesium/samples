using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractApiBillOfMaterialsRequestModelValidator : AbstractValidator<ApiBillOfMaterialsRequestModel>
        {
                private int existingRecordId;

                private IBillOfMaterialsRepository billOfMaterialsRepository;

                public AbstractApiBillOfMaterialsRequestModelValidator(IBillOfMaterialsRepository billOfMaterialsRepository)
                {
                        this.billOfMaterialsRepository = billOfMaterialsRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiBillOfMaterialsRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void BOMLevelRules()
                {
                }

                public virtual void ComponentIDRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByProductAssemblyIDComponentIDStartDate).When(x => x?.ComponentID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBillOfMaterialsRequestModel.ComponentID));
                }

                public virtual void EndDateRules()
                {
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void PerAssemblyQtyRules()
                {
                }

                public virtual void ProductAssemblyIDRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByProductAssemblyIDComponentIDStartDate).When(x => x?.ProductAssemblyID != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBillOfMaterialsRequestModel.ProductAssemblyID));
                }

                public virtual void StartDateRules()
                {
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByProductAssemblyIDComponentIDStartDate).When(x => x?.StartDate != null).WithMessage("Violates unique constraint").WithName(nameof(ApiBillOfMaterialsRequestModel.StartDate));
                }

                public virtual void UnitMeasureCodeRules()
                {
                        this.RuleFor(x => x.UnitMeasureCode).NotNull();
                        this.RuleFor(x => x.UnitMeasureCode).Length(0, 3);
                }

                private async Task<bool> BeUniqueByProductAssemblyIDComponentIDStartDate(ApiBillOfMaterialsRequestModel model,  CancellationToken cancellationToken)
                {
                        BillOfMaterials record = await this.billOfMaterialsRepository.ByProductAssemblyIDComponentIDStartDate(model.ProductAssemblyID, model.ComponentID, model.StartDate);

                        if (record == null || (this.existingRecordId != default(int) && record.BillOfMaterialsID == this.existingRecordId))
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
    <Hash>655f6940ec98e8e2386fd1799edb7d03</Hash>
</Codenesium>*/