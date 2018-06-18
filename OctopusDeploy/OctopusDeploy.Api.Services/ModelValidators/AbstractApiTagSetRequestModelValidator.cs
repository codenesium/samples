using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiTagSetRequestModelValidator: AbstractValidator<ApiTagSetRequestModel>
        {
                private string existingRecordId;

                ITagSetRepository tagSetRepository;

                public AbstractApiTagSetRequestModelValidator(ITagSetRepository tagSetRepository)
                {
                        this.tagSetRepository = tagSetRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiTagSetRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void DataVersionRules()
                {
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiTagSetRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void SortOrderRules()
                {
                }

                private async Task<bool> BeUniqueGetName(ApiTagSetRequestModel model,  CancellationToken cancellationToken)
                {
                        TagSet record = await this.tagSetRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default (string) && record.Id == this.existingRecordId))
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
    <Hash>72ad7790ad67399e80ce745602177585</Hash>
</Codenesium>*/