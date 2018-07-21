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
        public abstract class AbstractApiPostHistoryRequestModelValidator : AbstractValidator<ApiPostHistoryRequestModel>
        {
                private int existingRecordId;

                private IPostHistoryRepository postHistoryRepository;

                public AbstractApiPostHistoryRequestModelValidator(IPostHistoryRepository postHistoryRepository)
                {
                        this.postHistoryRepository = postHistoryRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiPostHistoryRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void CommentRules()
                {
                        this.RuleFor(x => x.Comment).Length(0, 1073741823);
                }

                public virtual void CreationDateRules()
                {
                }

                public virtual void PostHistoryTypeIdRules()
                {
                }

                public virtual void PostIdRules()
                {
                }

                public virtual void RevisionGUIDRules()
                {
                        this.RuleFor(x => x.RevisionGUID).Length(0, 36);
                }

                public virtual void TextRules()
                {
                        this.RuleFor(x => x.Text).Length(0, 1073741823);
                }

                public virtual void UserDisplayNameRules()
                {
                        this.RuleFor(x => x.UserDisplayName).Length(0, 40);
                }

                public virtual void UserIdRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>85d23c965739f00598ed0843ee25f29f</Hash>
</Codenesium>*/