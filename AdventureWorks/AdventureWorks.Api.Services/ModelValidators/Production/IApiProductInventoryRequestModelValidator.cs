using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

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
    <Hash>ae28b149f00c4c4816ad9191f409c2e5</Hash>
</Codenesium>*/