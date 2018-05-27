using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.BusinessObjects
{
	public interface IApiFileRequestModelValidator
	{
		Task<ValidationResult> ValidateCreateAsync(ApiFileRequestModel model);
		Task<ValidationResult> ValidateUpdateAsync(int id, ApiFileRequestModel model);
		Task<ValidationResult> ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>e345e3a7e09d8d3d9c9b56253f751ae7</Hash>
</Codenesium>*/