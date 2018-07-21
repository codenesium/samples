using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
        public partial class TestAllFieldTypeRepository : AbstractTestAllFieldTypeRepository, ITestAllFieldTypeRepository
        {
                public TestAllFieldTypeRepository(
                        ILogger<TestAllFieldTypeRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>c27a5dd03b69e9bc7da81bee8e111317</Hash>
</Codenesium>*/