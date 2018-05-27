using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiPersonPhoneRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiPersonPhoneRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiPersonPhoneRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>dfe04b4b031e03f5a3b88e1d4b09f52b</Hash>
</Codenesium>*/