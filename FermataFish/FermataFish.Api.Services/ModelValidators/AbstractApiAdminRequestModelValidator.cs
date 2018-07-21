using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public abstract class AbstractApiAdminRequestModelValidator : AbstractValidator<ApiAdminRequestModel>
        {
                private int existingRecordId;

                private IAdminRepository adminRepository;

                public AbstractApiAdminRequestModelValidator(IAdminRepository adminRepository)
                {
                        this.adminRepository = adminRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiAdminRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void BirthdayRules()
                {
                }

                public virtual void EmailRules()
                {
                        this.RuleFor(x => x.Email).Length(0, 128);
                }

                public virtual void FirstNameRules()
                {
                        this.RuleFor(x => x.FirstName).Length(0, 128);
                }

                public virtual void LastNameRules()
                {
                        this.RuleFor(x => x.LastName).Length(0, 128);
                }

                public virtual void PhoneRules()
                {
                        this.RuleFor(x => x.Phone).Length(0, 128);
                }

                public virtual void StudioIdRules()
                {
                        this.RuleFor(x => x.StudioId).MustAsync(this.BeValidStudio).When(x => x?.StudioId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidStudio(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.adminRepository.GetStudio(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>44b7e6ca2af445e9ee83a251b63993c9</Hash>
</Codenesium>*/