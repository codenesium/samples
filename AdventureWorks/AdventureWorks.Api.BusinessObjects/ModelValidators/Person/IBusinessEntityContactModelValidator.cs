using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiBusinessEntityContactModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityContactModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityContactModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b95ac3b00a753c62aa194a08e4956b76</Hash>
</Codenesium>*/