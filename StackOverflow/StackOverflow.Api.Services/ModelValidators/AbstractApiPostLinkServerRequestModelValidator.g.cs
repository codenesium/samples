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
	public abstract class AbstractApiPostLinkServerRequestModelValidator : AbstractValidator<ApiPostLinkServerRequestModel>
	{
		private int existingRecordId;

		private IPostLinkRepository postLinkRepository;

		public AbstractApiPostLinkServerRequestModelValidator(IPostLinkRepository postLinkRepository)
		{
			this.postLinkRepository = postLinkRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostLinkServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CreationDateRules()
		{
		}

		public virtual void LinkTypeIdRules()
		{
		}

		public virtual void PostIdRules()
		{
		}

		public virtual void RelatedPostIdRules()
		{
		}
	}
}

/*<Codenesium>
    <Hash>5d2d597027477228e94229e7beba2cd0</Hash>
</Codenesium>*/