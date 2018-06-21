using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
        public class UsersService : AbstractUsersService, IUsersService
        {
                public UsersService(
                        ILogger<IUsersRepository> logger,
                        IUsersRepository usersRepository,
                        IApiUsersRequestModelValidator usersModelValidator,
                        IBOLUsersMapper bolusersMapper,
                        IDALUsersMapper dalusersMapper
                        )
                        : base(logger,
                               usersRepository,
                               usersModelValidator,
                               bolusersMapper,
                               dalusersMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>82d0716f2ca5d075770accaa9e135126</Hash>
</Codenesium>*/