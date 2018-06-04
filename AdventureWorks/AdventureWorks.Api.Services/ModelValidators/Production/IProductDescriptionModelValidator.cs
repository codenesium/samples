using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductDescriptionRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductDescriptionRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductDescriptionRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>96e63e0827f66a2cd9999227cf0b1245</Hash>
</Codenesium>*/