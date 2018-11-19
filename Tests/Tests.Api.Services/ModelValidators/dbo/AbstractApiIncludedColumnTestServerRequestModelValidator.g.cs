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
	public abstract class AbstractApiIncludedColumnTestServerRequestModelValidator : AbstractValidator<ApiIncludedColumnTestServerRequestModel>
	{
		private int existingRecordId;

		private IIncludedColumnTestRepository includedColumnTestRepository;

		public AbstractApiIncludedColumnTestServerRequestModelValidator(IIncludedColumnTestRepository includedColumnTestRepository)
		{
			this.includedColumnTestRepository = includedColumnTestRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiIncludedColumnTestServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void Name2Rules()
		{
			this.RuleFor(x => x.Name2).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name2).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>1c96be99c8452af27d0eee07c691255b</Hash>
</Codenesium>*/