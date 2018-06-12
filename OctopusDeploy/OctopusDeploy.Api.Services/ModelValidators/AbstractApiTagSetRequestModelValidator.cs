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

                public ValidationResult Validate(ApiTagSetRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiTagSetRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ITagSetRepository TagSetRepository { get; set; }
                public virtual void DataVersionRules()
                {
                        this.RuleFor(x => x.DataVersion).NotNull();
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
                        this.RuleFor(x => x.SortOrder).NotNull();
                }

                private async Task<bool> BeUniqueGetName(ApiTagSetRequestModel model,  CancellationToken cancellationToken)
                {
                        TagSet record = await this.TagSetRepository.GetName(model.Name);

                        if (record == null || record.Id == this.existingRecordId)
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
    <Hash>535a854f7d6d74235c4f4bedcd35201f</Hash>
</Codenesium>*/