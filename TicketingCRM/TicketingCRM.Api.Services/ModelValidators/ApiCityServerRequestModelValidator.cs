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
	public class ApiCityServerRequestModelValidator : AbstractValidator<ApiCityServerRequestModel>, IApiCityServerRequestModelValidator
	{
		private int existingRecordId;

		protected ICityRepository CityRepository { get; private set; }

		public ApiCityServerRequestModelValidator(ICityRepository cityRepository)
		{
			this.CityRepository = cityRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiCityServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCityServerRequestModel model)
		{
			this.NameRules();
			this.ProvinceIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCityServerRequestModel model)
		{
			this.NameRules();
			this.ProvinceIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
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
    <Hash>eba99a3bb8c3d4ca68e5e27f5fb8e99c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/