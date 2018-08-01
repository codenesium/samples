using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductPhotoRequestModelValidator : AbstractApiProductPhotoRequestModelValidator, IApiProductPhotoRequestModelValidator
	{
		public ApiProductPhotoRequestModelValidator(IProductPhotoRepository productPhotoRepository)
			: base(productPhotoRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductPhotoRequestModel model)
		{
			this.LargePhotoRules();
			this.LargePhotoFileNameRules();
			this.ModifiedDateRules();
			this.ThumbNailPhotoRules();
			this.ThumbnailPhotoFileNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductPhotoRequestModel model)
		{
			this.LargePhotoRules();
			this.LargePhotoFileNameRules();
			this.ModifiedDateRules();
			this.ThumbNailPhotoRules();
			this.ThumbnailPhotoFileNameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>ca3373083c95e26dd330fba4363feaa6</Hash>
</Codenesium>*/