using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class ApiFamilyRequestModelValidator: AbstractApiFamilyRequestModelValidator, IApiFamilyRequestModelValidator
        {
                public ApiFamilyRequestModelValidator()
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>47068eb97df596cade8cbe47aaf2c68d</Hash>
</Codenesium>*/