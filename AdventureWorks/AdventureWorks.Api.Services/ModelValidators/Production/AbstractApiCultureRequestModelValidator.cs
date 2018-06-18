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
        public abstract class AbstractApiCultureRequestModelValidator: AbstractValidator<ApiCultureRequestModel>
        {
                private string existingRecordId;

                ICultureRepository cultureRepository;

                public AbstractApiCultureRequestModelValidator(ICultureRepository cultureRepository)
                {
                        this.cultureRepository = cultureRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiCultureRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiCultureRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                private async Task<bool> BeUniqueByName(ApiCultureRequestModel model,  CancellationToken cancellationToken)
                {
                        Culture record = await this.cultureRepository.ByName(model.Name);

                        if (record == null || (this.existingRecordId != default (string) && record.CultureID == this.existingRecordId))
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
    <Hash>322da4d1b19bcedf4604eca37048797b</Hash>
</Codenesium>*/