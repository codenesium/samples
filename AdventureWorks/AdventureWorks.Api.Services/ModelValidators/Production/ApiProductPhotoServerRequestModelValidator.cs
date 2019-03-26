using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductPhotoServerRequestModelValidator : AbstractApiProductPhotoServerRequestModelValidator, IApiProductPhotoServerRequestModelValidator
	{
		public ApiProductPhotoServerRequestModelValidator(IProductPhotoRepository productPhotoRepository)
			: base(productPhotoRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductPhotoServerRequestModel model)
		{
			this.LargePhotoRules();
			this.LargePhotoFileNameRules();
			this.ModifiedDateRules();
			this.ThumbNailPhotoRules();
			this.ThumbnailPhotoFileNameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductPhotoServerRequestModel model)
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
    <Hash>be77b3c223be063456a54a51a0ad7932</Hash>
</Codenesium>*/