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
	public abstract class AbstractApiTableServerRequestModelValidator : AbstractValidator<ApiTableServerRequestModel>
	{
		private int existingRecordId;

		protected ITableRepository TableRepository { get; private set; }

		public AbstractApiTableServerRequestModelValidator(ITableRepository tableRepository)
		{
			this.TableRepository = tableRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiTableServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>2728b150807778f2a0929e02072f88f0</Hash>
</Codenesium>*/