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

		private ICultureRepository cultureRepository;

		public AbstractApiCultureServerRequestModelValidator(ICultureRepository cultureRepository)
		{
			this.cultureRepository = cultureRepository;
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
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiCultureServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		private async Task<bool> BeUniqueByName(ApiCultureServerRequestModel model,  CancellationToken cancellationToken)
		{
			Culture record = await this.cultureRepository.ByName(model.Name);

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
    <Hash>735e44d5bc4e45b4811bf8e300f320d6</Hash>
</Codenesium>*/