using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductModelIllustrationModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelIllustrationModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelIllustrationModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>6c92837c44355f9f402bf4e697d6796e</Hash>
</Codenesium>*/