using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
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
    <Hash>1d7948a894ee0caa642d896dd0ce97df</Hash>
</Codenesium>*/