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
        public abstract class AbstractApiUnitMeasureRequestModelValidator: AbstractValidator<ApiUnitMeasureRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiUnitMeasureRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiUnitMeasureRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IUnitMeasureRepository UnitMeasureRepository { get; set; }
                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiUnitMeasureRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                private async Task<bool> BeUniqueGetName(ApiUnitMeasureRequestModel model,  CancellationToken cancellationToken)
                {
                        UnitMeasure record = await this.UnitMeasureRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default (string) && record.UnitMeasureCode == this.existingRecordId))
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
    <Hash>52b25aec506b79f3a541817617508808</Hash>
</Codenesium>*/