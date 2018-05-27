using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiBusinessEntityRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>59556c19f78f4320aa7c120d953c7566</Hash>
</Codenesium>*/