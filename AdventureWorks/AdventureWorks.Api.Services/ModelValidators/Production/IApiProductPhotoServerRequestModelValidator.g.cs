using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiProductPhotoServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductPhotoServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductPhotoServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>53107cc4732b7605b6fbe770adf845c8</Hash>
</Codenesium>*/