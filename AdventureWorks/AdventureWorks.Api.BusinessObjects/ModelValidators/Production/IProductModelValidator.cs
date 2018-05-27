using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IApiProductRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiProductRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>d591ddd561351a12161159967b852d11</Hash>
</Codenesium>*/