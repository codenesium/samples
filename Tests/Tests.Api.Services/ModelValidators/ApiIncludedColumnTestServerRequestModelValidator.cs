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
	public class ApiIncludedColumnTestServerRequestModelValidator : AbstractValidator<ApiIncludedColumnTestServerRequestModel>, IApiIncludedColumnTestServerRequestModelValidator
	{
		private int existingRecordId;

		protected IIncludedColumnTestRepository IncludedColumnTestRepository { get; private set; }

		public ApiIncludedColumnTestServerRequestModelValidator(IIncludedColumnTestRepository includedColumnTestRepository)
		{
			this.IncludedColumnTestRepository = includedColumnTestRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiIncludedColumnTestServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiIncludedColumnTestServerRequestModel model)
		{
			this.NameRules();
			this.Name2Rules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiIncludedColumnTestServerRequestModel model)
		{
			this.NameRules();
			this.Name2Rules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>d08f645ae7a5be04986f8ab9d5f1b39d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/