using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiVPersonServerRequestModelValidator : AbstractValidator<ApiVPersonServerRequestModel>
	{
		private int existingRecordId;

		protected IVPersonRepository VPersonRepository { get; private set; }

		public AbstractApiVPersonServerRequestModelValidator(IVPersonRepository vPersonRepository)
		{
			this.VPersonRepository = vPersonRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVPersonServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void PersonNameRules()
		{
			this.RuleFor(x => x.PersonName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.PersonName).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>d25f205bf2e02f5ac4d0b22e9a663b8f</Hash>
</Codenesium>*/