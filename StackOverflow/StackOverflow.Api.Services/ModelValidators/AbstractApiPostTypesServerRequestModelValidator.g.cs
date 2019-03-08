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
	public abstract class AbstractApiPostTypesServerRequestModelValidator : AbstractValidator<ApiPostTypesServerRequestModel>
	{
		private int existingRecordId;

		protected IPostTypesRepository PostTypesRepository { get; private set; }

		public AbstractApiPostTypesServerRequestModelValidator(IPostTypesRepository postTypesRepository)
		{
			this.PostTypesRepository = postTypesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPostTypesServerRequestModel model, int id)
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
    <Hash>bcbcded79f67e23cfbd4f2507e7290c0</Hash>
</Codenesium>*/