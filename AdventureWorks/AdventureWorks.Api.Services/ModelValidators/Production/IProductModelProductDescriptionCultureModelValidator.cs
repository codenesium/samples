using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiProductModelProductDescriptionCultureRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductModelProductDescriptionCultureRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelProductDescriptionCultureRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cfbfae447c15e2a0e29d7f1f0e724eab</Hash>
</Codenesium>*/