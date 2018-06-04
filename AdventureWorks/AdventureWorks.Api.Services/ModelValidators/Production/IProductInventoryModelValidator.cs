using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductInventoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductInventoryRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductInventoryRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ac4d962e6cbb63c1363cab149002fec7</Hash>
</Codenesium>*/