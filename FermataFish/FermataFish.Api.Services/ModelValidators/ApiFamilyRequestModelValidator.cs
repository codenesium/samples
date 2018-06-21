using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
        public class ApiFamilyRequestModelValidator : AbstractApiFamilyRequestModelValidator, IApiFamilyRequestModelValidator
        {
                public ApiFamilyRequestModelValidator(IFamilyRepository familyRepository)
                        : base(familyRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiFamilyRequestModel model)
                {
                        this.NotesRules();
                        this.PcEmailRules();
                        this.PcFirstNameRules();
                        this.PcLastNameRules();
                        this.PcPhoneRules();
                        this.StudioIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiFamilyRequestModel model)
                {
                        this.NotesRules();
                        this.PcEmailRules();
                        this.PcFirstNameRules();
                        this.PcLastNameRules();
                        this.PcPhoneRules();
                        this.StudioIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>0a35d0ab8c43bffcf69cec5d7fbab685</Hash>
</Codenesium>*/