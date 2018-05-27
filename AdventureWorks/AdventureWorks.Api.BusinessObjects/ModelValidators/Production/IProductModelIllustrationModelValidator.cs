using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductModelIllustrationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelIllustrationRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelIllustrationRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a2d8036ebb84ca7d50d5630454a7e078</Hash>
</Codenesium>*/