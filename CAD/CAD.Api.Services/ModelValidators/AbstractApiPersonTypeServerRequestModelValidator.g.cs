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
	public abstract class AbstractApiPersonTypeServerRequestModelValidator : AbstractValidator<ApiPersonTypeServerRequestModel>
	{
		private int existingRecordId;

		protected IPersonTypeRepository PersonTypeRepository { get; private set; }

		public AbstractApiPersonTypeServerRequestModelValidator(IPersonTypeRepository personTypeRepository)
		{
			this.PersonTypeRepository = personTypeRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiPersonTypeServerRequestModel model, int id)
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
    <Hash>4c8988415652df8674bda23945b82ed0</Hash>
</Codenesium>*/