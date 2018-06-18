using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class EmployeeService: AbstractEmployeeService, IEmployeeService
        {
                public EmployeeService(
                        ILogger<IEmployeeRepository> logger,
                        IEmployeeRepository employeeRepository,
                        IApiEmployeeRequestModelValidator employeeModelValidator,
                        IBOLEmployeeMapper bolemployeeMapper,
                        IDALEmployeeMapper dalemployeeMapper
                        ,
                        IBOLClientCommunicationMapper bolClientCommunicationMapper,
                        IDALClientCommunicationMapper dalClientCommunicationMapper
                        ,
                        IBOLPipelineStepMapper bolPipelineStepMapper,
                        IDALPipelineStepMapper dalPipelineStepMapper
                        ,
                        IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
                        IDALPipelineStepNoteMapper dalPipelineStepNoteMapper

                        )
                        : base(logger,
                               employeeRepository,
                               employeeModelValidator,
                               bolemployeeMapper,
                               dalemployeeMapper
                               ,
                               bolClientCommunicationMapper,
                               dalClientCommunicationMapper
                               ,
                               bolPipelineStepMapper,
                               dalPipelineStepMapper
                               ,
                               bolPipelineStepNoteMapper,
                               dalPipelineStepNoteMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>cb501e1d03f09b913da1dd7b87929f10</Hash>
</Codenesium>*/