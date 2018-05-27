using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiLocationRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiLocationRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(short id, ApiLocationRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(short id);
	}
}

/*<Codenesium>
    <Hash>90b8161f1a8b28912fca14f1139cadcd</Hash>
</Codenesium>*/