using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiLinkTypeServerRequestModelValidator : AbstractValidator<ApiLinkTypeServerRequestModel>
	{
		private int existingRecordId;

		private ILinkTypeRepository linkTypeRepository;

		public AbstractApiLinkTypeServerRequestModelValidator(ILinkTypeRepository linkTypeRepository)
		{
			this.linkTypeRepository = linkTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiLinkTypeServerRequestModel model, int id)
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
    <Hash>9ac294ff09313cd74f542d9066953293</Hash>
</Codenesium>*/