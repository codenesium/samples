using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class CustomerService: AbstractCustomerService, ICustomerService
        {
                public CustomerService(
                        ILogger<CustomerRepository> logger,
                        ICustomerRepository customerRepository,
                        IApiCustomerRequestModelValidator customerModelValidator,
                        IBOLCustomerMapper bolcustomerMapper,
                        IDALCustomerMapper dalcustomerMapper
                        ,
                        IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
                        IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper

                        )
                        : base(logger,
                               customerRepository,
                               customerModelValidator,
                               bolcustomerMapper,
                               dalcustomerMapper
                               ,
                               bolSalesOrderHeaderMapper,
                               dalSalesOrderHeaderMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>87f466c2b2d0904571796e8a3fbe2540</Hash>
</Codenesium>*/