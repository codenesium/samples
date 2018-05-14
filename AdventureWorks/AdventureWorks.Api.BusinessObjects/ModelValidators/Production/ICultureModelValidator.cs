using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiCultureModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiCultureModel model);
		Task<ValidationResult> ValidateUpdateAsync(string id, ApiCultureModel model);
		Task<ValidationResult> ValidateDeleteAsync(string id);
	}
}

/*<Codenesium>
    <Hash>959be278741a2c54fdfcc9e360a0172f</Hash>
</Codenesium>*/