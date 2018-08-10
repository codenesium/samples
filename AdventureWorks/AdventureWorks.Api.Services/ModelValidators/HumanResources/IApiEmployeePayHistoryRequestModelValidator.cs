using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IApiEmployeePayHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeePayHistoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeePayHistoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>ae7c086bc6f3d448d2223c6cc24cf9fd</Hash>
</Codenesium>*/