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
	public abstract class AbstractApiOffCapabilityServerRequestModelValidator : AbstractValidator<ApiOffCapabilityServerRequestModel>
	{
		private int existingRecordId;

		protected IOffCapabilityRepository OffCapabilityRepository { get; private set; }

		public AbstractApiOffCapabilityServerRequestModelValidator(IOffCapabilityRepository offCapabilityRepository)
		{
			this.OffCapabilityRepository = offCapabilityRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiOffCapabilityServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>125cc83bdd9b08caedc2475582b090f7</Hash>
</Codenesium>*/