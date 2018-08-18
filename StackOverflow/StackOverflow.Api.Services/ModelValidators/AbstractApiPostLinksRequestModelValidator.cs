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
	public abstract class AbstractApiPostLinksRequestModelValidator : AbstractValidator<ApiPostLinksRequestModel>
	{
		private int existingRecordId;

		private IPostLinksRepository postLinksRepository;

		public AbstractApiPostLinksRequestModelValidator(IPostLinksRepository postLinksRepository)
		{
			this.postLinksRepository = postLinksRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostLinksRequestModel model, int id)
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
    <Hash>ba69180a3a3e7cc876bb13f271cc649c</Hash>
</Codenesium>*/