using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Services
{
	public interface IApiClaspRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiClaspRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiClaspRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>daa11cfdcb2e6b54c2e90475ec2e2bc3</Hash>
</Codenesium>*/