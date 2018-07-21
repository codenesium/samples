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
        public abstract class AbstractApiPersonRequestModelValidator : AbstractValidator<ApiPersonRequestModel>
        {
                private int existingRecordId;

                private IPersonRepository personRepository;

                public AbstractApiPersonRequestModelValidator(IPersonRepository personRepository)
                {
                        this.personRepository = personRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiPersonRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AdditionalContactInfoRules()
                {
                }

                public virtual void DemographicRules()
                {
                }

                public virtual void EmailPromotionRules()
                {
                }

                public virtual void FirstNameRules()
                {
                        this.RuleFor(x => x.FirstName).NotNull();
                        this.RuleFor(x => x.FirstName).Length(0, 50);
                }

                public virtual void LastNameRules()
                {
                        this.RuleFor(x => x.LastName).NotNull();
                        this.RuleFor(x => x.LastName).Length(0, 50);
                }

                public virtual void MiddleNameRules()
                {
                        this.RuleFor(x => x.MiddleName).Length(0, 50);
                }

                public virtual void ModifiedDateRules()
                {
                }

                public virtual void NameStyleRules()
                {
                }

                public virtual void PersonTypeRules()
                {
                        this.RuleFor(x => x.PersonType).NotNull();
                        this.RuleFor(x => x.PersonType).Length(0, 2);
                }

                public virtual void RowguidRules()
                {
                }

                public virtual void SuffixRules()
                {
                        this.RuleFor(x => x.Suffix).Length(0, 10);
                }

                public virtual void TitleRules()
                {
                        this.RuleFor(x => x.Title).Length(0, 8);
                }
        }
}

/*<Codenesium>
    <Hash>70c1be84d9a0bd9af44ec39f8a5ed042</Hash>
</Codenesium>*/