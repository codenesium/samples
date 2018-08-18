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
	public abstract class AbstractApiLinkTypesRequestModelValidator : AbstractValidator<ApiLinkTypesRequestModel>
	{
		private int existingRecordId;

		private ILinkTypesRepository linkTypesRepository;

		public AbstractApiLinkTypesRequestModelValidator(ILinkTypesRepository linkTypesRepository)
		{
			this.linkTypesRepository = linkTypesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkTypesRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void TypeRules()
		{
			this.RuleFor(x => x.Type).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>40742c0acc6f9bffc41eba6ab7a47cb0</Hash>
</Codenesium>*/