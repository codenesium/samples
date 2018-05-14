using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiBusinessEntityModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiBusinessEntityModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiBusinessEntityModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>f6ddb7b869c48d75fcd883ffeef3cbb1</Hash>
</Codenesium>*/