using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class CustomerService : AbstractCustomerService, ICustomerService
        {
                public CustomerService(
                        ILogger<ICustomerRepository> logger,
                        ICustomerRepository customerRepository,
                        IApiCustomerRequestModelValidator customerModelValidator,
                        IBOLCustomerMapper bolcustomerMapper,
                        IDALCustomerMapper dalcustomerMapper
                        )
                        : base(logger,
                               customerRepository,
                               customerModelValidator,
                               bolcustomerMapper,
                               dalcustomerMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f8e475f479bd089e4205270af3948573</Hash>
</Codenesium>*/