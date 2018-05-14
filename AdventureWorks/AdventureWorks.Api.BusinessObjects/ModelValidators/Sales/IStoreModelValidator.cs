using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiStoreModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiStoreModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiStoreModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>7ecee9fd768a0648b36c14d7a828065b</Hash>
</Codenesium>*/