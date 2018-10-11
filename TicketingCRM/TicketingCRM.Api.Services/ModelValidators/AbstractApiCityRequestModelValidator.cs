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
	public abstract class AbstractApiCityRequestModelValidator : AbstractValidator<ApiCityRequestModel>
	{
		private int existingRecordId;

		private ICityRepository cityRepository;

		public AbstractApiCityRequestModelValidator(ICityRepository cityRepository)
		{
			this.cityRepository = cityRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCityRequestModel model, int id)
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
			this.RuleFor(x => x.ProvinceId).MustAsync(this.BeValidProvinceByProvinceId).When(x => x?.ProvinceId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidProvinceByProvinceId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.cityRepository.ProvinceByProvinceId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>09bff14665f8dcb20b3bbaab0396dbe7</Hash>
</Codenesium>*/