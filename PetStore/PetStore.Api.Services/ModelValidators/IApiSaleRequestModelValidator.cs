using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IApiSaleRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSaleRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fb42f64082299f818bd1ae83bd101b25</Hash>
</Codenesium>*/