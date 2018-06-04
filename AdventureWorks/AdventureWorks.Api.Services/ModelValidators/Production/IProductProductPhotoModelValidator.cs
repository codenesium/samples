using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
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
    <Hash>19f83e301a8ed282a3b0f503442e4350</Hash>
</Codenesium>*/