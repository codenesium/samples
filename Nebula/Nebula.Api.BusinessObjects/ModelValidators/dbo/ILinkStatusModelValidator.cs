using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.BusinessObjects
{
	public interface ILinkStatusModelValidator
	{
		Task<ValidationResult>  ValidateCreateAsync(LinkStatusModel model);
		Task<ValidationResult>  ValidateUpdateAsync(int id, LinkStatusModel model);
		Task<ValidationResult>  ValidateDeleteAsync(int id);
	}
}

/*<Codenesium>
    <Hash>fa3f124b736473b59584206c8d274858</Hash>
</Codenesium>*/