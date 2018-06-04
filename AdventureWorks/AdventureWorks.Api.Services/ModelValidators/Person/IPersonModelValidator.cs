using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiPersonRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>cd72a39325e0253bbd168e37eabfd97e</Hash>
</Codenesium>*/