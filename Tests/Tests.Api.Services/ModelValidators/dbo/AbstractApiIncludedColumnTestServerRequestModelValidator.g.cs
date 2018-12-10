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

		protected IIncludedColumnTestRepository IncludedColumnTestRepository { get; private set; }

		public AbstractApiIncludedColumnTestServerRequestModelValidator(IIncludedColumnTestRepository includedColumnTestRepository)
		{
			this.IncludedColumnTestRepository = includedColumnTestRepository;
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
    <Hash>e45cae6ecb2fd3eacb04c5d8110e3c46</Hash>
</Codenesium>*/