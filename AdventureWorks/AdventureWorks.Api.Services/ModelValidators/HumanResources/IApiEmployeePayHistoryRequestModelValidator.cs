using AdventureWorksNS.Api.Contracts;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public interface IApiEmployeePayHistoryRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiEmployeePayHistoryRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiEmployeePayHistoryRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e54ce07e11106fa45d71064a7d8850ad</Hash>
</Codenesium>*/