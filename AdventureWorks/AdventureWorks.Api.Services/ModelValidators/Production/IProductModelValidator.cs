using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a5638b3d5316675c9b936120be1d050c</Hash>
</Codenesium>*/