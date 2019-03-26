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
	public abstract class AbstractApiPostTypeServerRequestModelValidator : AbstractValidator<ApiPostTypeServerRequestModel>
	{
		private int existingRecordId;

		protected IPostTypeRepository PostTypeRepository { get; private set; }

		public AbstractApiPostTypeServerRequestModelValidator(IPostTypeRepository postTypeRepository)
		{
			this.PostTypeRepository = postTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostTypeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void RwTypeRules()
		{
			this.RuleFor(x => x.RwType).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.RwType).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>16d89dbe494829d069337592e256beca</Hash>
</Codenesium>*/