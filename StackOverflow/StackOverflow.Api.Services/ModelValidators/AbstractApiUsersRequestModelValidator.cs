using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
        public abstract class AbstractApiUsersRequestModelValidator : AbstractValidator<ApiUsersRequestModel>
        {
                private int existingRecordId;

                private IUsersRepository usersRepository;

                public AbstractApiUsersRequestModelValidator(IUsersRepository usersRepository)
                {
                        this.usersRepository = usersRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiUsersRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AboutMeRules()
                {
                }

                public virtual void AccountIdRules()
                {
                }

                public virtual void AgeRules()
                {
                }

                public virtual void CreationDateRules()
                {
                }

                public virtual void DisplayNameRules()
                {
                        this.RuleFor(x => x.DisplayName).Length(0, 40);
                }

                public virtual void DownVotesRules()
                {
                }

                public virtual void EmailHashRules()
                {
                        this.RuleFor(x => x.EmailHash).Length(0, 40);
                }

                public virtual void LastAccessDateRules()
                {
                }

                public virtual void LocationRules()
                {
                        this.RuleFor(x => x.Location).Length(0, 100);
                }

                public virtual void ReputationRules()
                {
                }

                public virtual void UpVotesRules()
                {
                }

                public virtual void ViewsRules()
                {
                }

                public virtual void WebsiteUrlRules()
                {
                        this.RuleFor(x => x.WebsiteUrl).Length(0, 200);
                }
        }
}

/*<Codenesium>
    <Hash>ebd1e39449a53c1f881a6be0e164df71</Hash>
</Codenesium>*/