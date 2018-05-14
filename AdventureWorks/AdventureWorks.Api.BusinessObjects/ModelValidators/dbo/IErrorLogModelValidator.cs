using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiErrorLogModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiErrorLogModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiErrorLogModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>b46d2fae740e6a4692c08146d6b2e7c4</Hash>
</Codenesium>*/