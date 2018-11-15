using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiCityServerRequestModelValidator : AbstractValidator<ApiCityServerRequestModel>
	{
		private int existingRecordId;

		private ICityRepository cityRepository;

		public AbstractApiCityServerRequestModelValidator(ICityRepository cityRepository)
		{
			this.cityRepository = cityRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCityServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x.Name).Length(0, 128);
		}

		public virtual void ProvinceIdRules()
		{
			this.RuleFor(x => x.ProvinceId).MustAsync(this.BeValidProvinceByProvinceId).When(x => !x?.ProvinceId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidProvinceByProvinceId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.cityRepository.ProvinceByProvinceId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>66f2fdbca4713c579c8fd95315e4303a</Hash>
</Codenesium>*/