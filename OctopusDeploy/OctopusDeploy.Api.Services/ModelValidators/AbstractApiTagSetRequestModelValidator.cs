using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiTagSetRequestModelValidator : AbstractValidator<ApiTagSetRequestModel>
        {
                private string existingRecordId;

                private ITagSetRepository tagSetRepository;

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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiTagSetRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void SortOrderRules()
                {
                }

                private async Task<bool> BeUniqueGetName(ApiTagSetRequestModel model,  CancellationToken cancellationToken)
                {
                        TagSet record = await this.tagSetRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
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
    <Hash>ecdf15d1a7ce7085483c638ad9eada58</Hash>
</Codenesium>*/