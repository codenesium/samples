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
	public abstract class AbstractApiSpeciesServerRequestModelValidator : AbstractValidator<ApiSpeciesServerRequestModel>
	{
		private int existingRecordId;

		protected ISpeciesRepository SpeciesRepository { get; private set; }

		public AbstractApiSpeciesServerRequestModelValidator(ISpeciesRepository speciesRepository)
		{
			this.SpeciesRepository = speciesRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSpeciesServerRequestModel model, int id)
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
    <Hash>036a1b25aad173a673b045b1b00deb07</Hash>
</Codenesium>*/