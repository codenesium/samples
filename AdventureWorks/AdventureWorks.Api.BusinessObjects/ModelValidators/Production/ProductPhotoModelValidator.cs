using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiProductPhotoModelValidator: AbstractApiProductPhotoModelValidator, IApiProductPhotoModelValidator
	{
		public ApiProductPhotoModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductPhotoModel model)
		{
			this.LargePhotoRules();
			this.LargePhotoFileNameRules();
			this.ModifiedDateRules();
			this.ThumbNailPhotoRules();
			this.ThumbnailPhotoFileNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductPhotoModel model)
		{
			this.LargePhotoRules();
			this.LargePhotoFileNameRules();
			this.ModifiedDateRules();
			this.ThumbNailPhotoRules();
			this.ThumbnailPhotoFileNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>614b6ad13ba573b695f8d363eee49fea</Hash>
</Codenesium>*/