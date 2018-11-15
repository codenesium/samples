using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiProvinceServerRequestModelValidator : AbstractValidator<ApiProvinceServerRequestModel>
	{
		private int existingRecordId;

		private IProvinceRepository provinceRepository;

		public AbstractApiProvinceServerRequestModelValidator(IProvinceRepository provinceRepository)
		{
			this.provinceRepository = provinceRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiProvinceServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CountryIdRules()
		{
			this.RuleFor(x => x.CountryId).MustAsync(this.BeValidCountryByCountryId).When(x => !x?.CountryId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		private async Task<bool> BeValidCountryByCountryId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.provinceRepository.CountryByCountryId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>fc585e4d211543f2faa01e65d16497f0</Hash>
</Codenesium>*/