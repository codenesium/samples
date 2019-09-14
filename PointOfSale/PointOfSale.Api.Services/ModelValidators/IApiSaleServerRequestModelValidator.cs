using FluentValidation.Results;
using PointOfSaleNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public partial interface IApiSaleServerRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiSaleServerRequestModel model);

		Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleServerRequestModel model);

		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>a896654a84853b1056b738fafe4d3fde</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/