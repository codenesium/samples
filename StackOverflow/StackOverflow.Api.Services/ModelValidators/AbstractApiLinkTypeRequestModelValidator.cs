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
	public abstract class AbstractApiLinkTypeRequestModelValidator : AbstractValidator<ApiLinkTypeRequestModel>
	{
		private int existingRecordId;

		private ILinkTypeRepository linkTypeRepository;

		public AbstractApiLinkTypeRequestModelValidator(ILinkTypeRepository linkTypeRepository)
		{
			this.linkTypeRepository = linkTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkTypeRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void TypeRules()
		{
			this.RuleFor(x => x.Type).NotNull();
			this.RuleFor(x => x.Type).Length(0, 50);
		}
	}
}

/*<Codenesium>
    <Hash>bccf2a11eba2d4c1d0284dc4a20930db</Hash>
</Codenesium>*/