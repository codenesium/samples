using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiStudioServerRequestModelValidator : AbstractValidator<ApiStudioServerRequestModel>, IApiStudioServerRequestModelValidator
	{
		private int existingRecordId;

		protected IStudioRepository StudioRepository { get; private set; }

		public ApiStudioServerRequestModelValidator(IStudioRepository studioRepository)
		{
			this.StudioRepository = studioRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiStudioServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiStudioServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.NameRules();
			this.ProvinceRules();
			this.WebsiteRules();
			this.ZipRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiStudioServerRequestModel model)
		{
			this.Address1Rules();
			this.Address2Rules();
			this.CityRules();
			this.NameRules();
			this.ProvinceRules();
			this.WebsiteRules();
			this.ZipRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void Address1Rules()
		{
			this.RuleFor(x => x.Address1).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Address1).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void Address2Rules()
		{
			this.RuleFor(x => x.Address2).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Address2).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void CityRules()
		{
			this.RuleFor(x => x.City).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.City).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ProvinceRules()
		{
			this.RuleFor(x => x.Province).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Province).Length(0, 90).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void WebsiteRules()
		{
			this.RuleFor(x => x.Website).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Website).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ZipRules()
		{
			this.RuleFor(x => x.Zip).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}
	}
}

/*<Codenesium>
    <Hash>8610548e5d9f154520c3772516be533e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/