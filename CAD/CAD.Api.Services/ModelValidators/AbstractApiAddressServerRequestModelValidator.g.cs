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
	public abstract class AbstractApiAddressServerRequestModelValidator : AbstractValidator<ApiAddressServerRequestModel>
	{
		private int existingRecordId;

		protected IAddressRepository AddressRepository { get; private set; }

		public AbstractApiAddressServerRequestModelValidator(IAddressRepository addressRepository)
		{
			this.AddressRepository = addressRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiAddressServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
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
    <Hash>417b8c4d9f0d7948ef5e4af707ba5f09</Hash>
</Codenesium>*/