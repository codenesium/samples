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

		protected IPostLinkRepository PostLinkRepository { get; private set; }

		public AbstractApiPostLinkServerRequestModelValidator(IPostLinkRepository postLinkRepository)
		{
			this.PostLinkRepository = postLinkRepository;
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
    <Hash>9d3dcfeff014c275fa160d8303cf5aa6</Hash>
</Codenesium>*/