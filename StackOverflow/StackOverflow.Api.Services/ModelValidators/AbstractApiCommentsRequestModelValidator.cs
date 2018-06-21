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
        public abstract class AbstractApiCommentsRequestModelValidator : AbstractValidator<ApiCommentsRequestModel>
        {
                private int existingRecordId;

                private ICommentsRepository commentsRepository;

                public AbstractApiCommentsRequestModelValidator(ICommentsRepository commentsRepository)
                {
                        this.commentsRepository = commentsRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiCommentsRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void CreationDateRules()
                {
                }

                public virtual void PostIdRules()
                {
                }

                public virtual void ScoreRules()
                {
                }

                public virtual void TextRules()
                {
                        this.RuleFor(x => x.Text).NotNull();
                        this.RuleFor(x => x.Text).Length(0, 700);
                }

                public virtual void UserIdRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>86fe725e8664f8b89ab161a78cee04dc</Hash>
</Codenesium>*/