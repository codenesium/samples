using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductProductPhotoRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductProductPhotoRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductProductPhotoRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>76a268b11edadb7a63158ebb5f564071</Hash>
</Codenesium>*/