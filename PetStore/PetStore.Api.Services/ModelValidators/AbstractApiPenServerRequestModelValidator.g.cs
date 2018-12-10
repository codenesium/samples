using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public abstract class AbstractApiPenServerRequestModelValidator : AbstractValidator<ApiPenServerRequestModel>
	{
		private int existingRecordId;

		protected IPenRepository PenRepository { get; private set; }

		public AbstractApiPenServerRequestModelValidator(IPenRepository penRepository)
		{
			this.PenRepository = penRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPenServerRequestModel model, int id)
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
    <Hash>9b3cc7b2a2a6d531bf8b36e33d2af7e4</Hash>
</Codenesium>*/