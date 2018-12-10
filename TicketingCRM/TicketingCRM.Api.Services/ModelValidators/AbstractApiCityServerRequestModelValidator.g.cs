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
	public abstract class AbstractApiCityServerRequestModelValidator : AbstractValidator<ApiCityServerRequestModel>
	{
		private int existingRecordId;

		protected ICityRepository CityRepository { get; private set; }

		public AbstractApiCityServerRequestModelValidator(ICityRepository cityRepository)
		{
			this.CityRepository = cityRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCityServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ProvinceIdRules()
		{
			this.RuleFor(x => x.ProvinceId).MustAsync(this.BeValidProvinceByProvinceId).When(x => !x?.ProvinceId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidProvinceByProvinceId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.CityRepository.ProvinceByProvinceId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>6a9747bfd68b698d75f3d80ac63ad622</Hash>
</Codenesium>*/