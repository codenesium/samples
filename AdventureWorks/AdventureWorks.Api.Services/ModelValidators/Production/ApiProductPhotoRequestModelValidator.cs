using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductPhotoRequestModelValidator: AbstractApiProductPhotoRequestModelValidator, IApiProductPhotoRequestModelValidator
	{
		public ApiProductPhotoRequestModelValidator()
		{   }

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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>d594d3a640f178fe2dd8f4e485231ee4</Hash>
</Codenesium>*/