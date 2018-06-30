using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public interface IDALTagsMapper
        {
                Tags MapBOToEF(
                        BOTags bo);

                BOTags MapEFToBO(
                        Tags efTags);

                List<BOTags> MapEFToBO(
                        List<Tags> records);
        }
}

/*<Codenesium>
    <Hash>93c875e909134627172dd5141c47b4f1</Hash>
</Codenesium>*/