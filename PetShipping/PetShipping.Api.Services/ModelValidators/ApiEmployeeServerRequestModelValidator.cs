using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiEmployeeServerRequestModelValidator : AbstractValidator<ApiEmployeeServerRequestModel>, IApiEmployeeServerRequestModelValidator
	{
		private int existingRecordId;

		protected IEmployeeRepository EmployeeRepository { get; private set; }

		public ApiEmployeeServerRequestModelValidator(IEmployeeRepository employeeRepository)
		{
			this.EmployeeRepository = employeeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiEmployeeServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiEmployeeServerRequestModel model)
		{
			this.FirstNameRules();
			this.IsSalesPersonRules();
			this.IsShipperRules();
			this.LastNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeeServerRequestModel model)
		{
			this.FirstNameRules();
			this.IsSalesPersonRules();
			this.IsShipperRules();
			this.LastNameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FirstName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void IsSalesPersonRules()
		{
		}

		public virtual void IsShipperRules()
		{
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.LastName).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>59b1cd62841e4957347a026b94fc78ed</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/