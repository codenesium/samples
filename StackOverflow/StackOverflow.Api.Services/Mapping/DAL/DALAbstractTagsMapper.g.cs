using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public abstract class DALAbstractTagsMapper
        {
                public virtual Tags MapBOToEF(
                        BOTags bo)
                {
                        Tags efTags = new Tags();
                        efTags.SetProperties(
                                bo.Count,
                                bo.ExcerptPostId,
                                bo.Id,
                                bo.TagName,
                                bo.WikiPostId);
                        return efTags;
                }

                public virtual BOTags MapEFToBO(
                        Tags ef)
                {
                        var bo = new BOTags();

                        bo.SetProperties(
                                ef.Id,
                                ef.Count,
                                ef.ExcerptPostId,
                                ef.TagName,
                                ef.WikiPostId);
                        return bo;
                }

                public virtual List<BOTags> MapEFToBO(
                        List<Tags> records)
                {
                        List<BOTags> response = new List<BOTags>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>72871265f67e4344f34a97e80239a607</Hash>
</Codenesium>*/