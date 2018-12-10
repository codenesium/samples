using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiProvinceServerRequestModelValidator : AbstractValidator<ApiProvinceServerRequestModel>
	{
		private int existingRecordId;

		protected IProvinceRepository ProvinceRepository { get; private set; }

		public AbstractApiProvinceServerRequestModelValidator(IProvinceRepository provinceRepository)
		{
			this.ProvinceRepository = provinceRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProvinceServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CountryIdRules()
		{
			this.RuleFor(x => x.CountryId).MustAsync(this.BeValidCountryByCountryId).When(x => !x?.CountryId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidCountryByCountryId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.ProvinceRepository.CountryByCountryId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>1b651be31a22a422f9fc0ca92ffd4f15</Hash>
</Codenesium>*/