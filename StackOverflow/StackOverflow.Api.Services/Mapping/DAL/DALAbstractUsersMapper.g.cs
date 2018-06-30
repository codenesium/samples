using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public abstract class DALAbstractUsersMapper
        {
                public virtual Users MapBOToEF(
                        BOUsers bo)
                {
                        Users efUsers = new Users();
                        efUsers.SetProperties(
                                bo.AboutMe,
                                bo.AccountId,
                                bo.Age,
                                bo.CreationDate,
                                bo.DisplayName,
                                bo.DownVotes,
                                bo.EmailHash,
                                bo.Id,
                                bo.LastAccessDate,
                                bo.Location,
                                bo.Reputation,
                                bo.UpVotes,
                                bo.Views,
                                bo.WebsiteUrl);
                        return efUsers;
                }

                public virtual BOUsers MapEFToBO(
                        Users ef)
                {
                        var bo = new BOUsers();

                        bo.SetProperties(
                                ef.Id,
                                ef.AboutMe,
                                ef.AccountId,
                                ef.Age,
                                ef.CreationDate,
                                ef.DisplayName,
                                ef.DownVotes,
                                ef.EmailHash,
                                ef.LastAccessDate,
                                ef.Location,
                                ef.Reputation,
                                ef.UpVotes,
                                ef.Views,
                                ef.WebsiteUrl);
                        return bo;
                }

                public virtual List<BOUsers> MapEFToBO(
                        List<Users> records)
                {
                        List<BOUsers> response = new List<BOUsers>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a47146492f6a9155ccf018b6db08f9ee</Hash>
</Codenesium>*/