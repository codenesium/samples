using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.Services
{
	public interface IApiBusinessEntityRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>2ba1ecd5950962c6d792d063f353cdda</Hash>
</Codenesium>*/