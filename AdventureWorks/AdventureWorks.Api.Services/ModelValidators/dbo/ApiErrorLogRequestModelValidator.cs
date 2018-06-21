using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public class ApiErrorLogRequestModelValidator : AbstractApiErrorLogRequestModelValidator, IApiErrorLogRequestModelValidator
        {
                public ApiErrorLogRequestModelValidator(IErrorLogRepository errorLogRepository)
                        : base(errorLogRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiErrorLogRequestModel model)
                {
                        this.ErrorLineRules();
                        this.ErrorMessageRules();
                        this.ErrorNumberRules();
                        this.ErrorProcedureRules();
                        this.ErrorSeverityRules();
                        this.ErrorStateRules();
                        this.ErrorTimeRules();
                        this.UserNameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiErrorLogRequestModel model)
                {
                        this.ErrorLineRules();
                        this.ErrorMessageRules();
                        this.ErrorNumberRules();
                        this.ErrorProcedureRules();
                        this.ErrorSeverityRules();
                        this.ErrorStateRules();
                        this.ErrorTimeRules();
                        this.UserNameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>02655ce8ec6747f9ece6aa555b15f829</Hash>
</Codenesium>*/