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
			this.PersonNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonServerRequestModel model)
		{
			this.PersonNameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void PersonNameRules()
		{
			this.RuleFor(x => x.PersonName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.PersonName).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>692c9151e81dc3be088a4c62e385ebea</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/