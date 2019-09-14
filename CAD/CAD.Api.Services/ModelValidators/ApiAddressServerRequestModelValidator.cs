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
	public class ApiAddressServerRequestModelValidator : AbstractValidator<ApiAddressServerRequestModel>, IApiAddressServerRequestModelValidator
	{
		private int existingRecordId;

		protected IAddressRepository AddressRepository { get; private set; }

		public ApiAddressServerRequestModelValidator(IAddressRepository addressRepository)
		{
			this.AddressRepository = addressRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiAddressServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiAddressServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.StateRules();
			this.ZipRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAddressServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.StateRules();
			this.ZipRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void Address1Rules()
		{
			this.RuleFor(x => x.Address1).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Address1).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void Address2Rules()
		{
			this.RuleFor(x => x.Address2).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void CityRules()
		{
			this.RuleFor(x => x.City).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.City).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void StateRules()
		{
			this.RuleFor(x => x.State).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.State).Length(0, 2).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ZipRules()
		{
			this.RuleFor(x => x.Zip).Length(0, 12).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>74c23469634ea2584ebf3c1704ac466d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/