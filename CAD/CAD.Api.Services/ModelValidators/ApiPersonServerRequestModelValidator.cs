using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiPersonServerRequestModelValidator : AbstractValidator<ApiPersonServerRequestModel>, IApiPersonServerRequestModelValidator
	{
		private int existingRecordId;

		protected IPersonRepository PersonRepository { get; private set; }

		public ApiPersonServerRequestModelValidator(IPersonRepository personRepository)
		{
			this.PersonRepository = personRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPersonServerRequestModel model)
		{
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.SsnRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonServerRequestModel model)
		{
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			this.SsnRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).Length(0, 32).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void SsnRules()
		{
			this.RuleFor(x => x.Ssn).Length(0, 12).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>3ef2af4625dfa74eac99757095f8d662</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/