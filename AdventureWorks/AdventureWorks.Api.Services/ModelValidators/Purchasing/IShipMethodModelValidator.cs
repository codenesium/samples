using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiShipMethodRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiShipMethodRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiShipMethodRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>19ddd88b139d380c28b8223cfffc3447</Hash>
</Codenesium>*/