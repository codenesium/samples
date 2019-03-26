using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiCultureServerRequestModelValidator : AbstractValidator<ApiCultureServerRequestModel>
	{
		private string existingRecordId;

		protected ICultureRepository CultureRepository { get; private set; }

		public AbstractApiCultureServerRequestModelValidator(ICultureRepository cultureRepository)
		{
			this.CultureRepository = cultureRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCultureServerRequestModel model, string id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => (!x?.Name.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiCultureServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeUniqueByName(ApiCultureServerRequestModel model,  CancellationToken cancellationToken)
		{
			Culture record = await this.CultureRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(string) && record.CultureID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>76aa4f0967f92b92ee2b557872773d7b</Hash>
</Codenesium>*/