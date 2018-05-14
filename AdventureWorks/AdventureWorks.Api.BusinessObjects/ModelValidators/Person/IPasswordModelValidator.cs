using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiPasswordModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPasswordModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPasswordModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ba873c87006f5c242474104da6d113b2</Hash>
</Codenesium>*/