using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public abstract class BOLAbstractUsersMapper
        {
                public virtual BOUsers MapModelToBO(
                        int id,
                        ApiUsersRequestModel model
                        )
                {
                        BOUsers boUsers = new BOUsers();
                        boUsers.SetProperties(
                                id,
                                model.AboutMe,
                                model.AccountId,
                                model.Age,
                                model.CreationDate,
                                model.DisplayName,
                                model.DownVotes,
                                model.EmailHash,
                                model.LastAccessDate,
                                model.Location,
                                model.Reputation,
                                model.UpVotes,
                                model.Views,
                                model.WebsiteUrl);
                        return boUsers;
                }

                public virtual ApiUsersResponseModel MapBOToModel(
                        BOUsers boUsers)
                {
                        var model = new ApiUsersResponseModel();

                        model.SetProperties(boUsers.AboutMe, boUsers.AccountId, boUsers.Age, boUsers.CreationDate, boUsers.DisplayName, boUsers.DownVotes, boUsers.EmailHash, boUsers.Id, boUsers.LastAccessDate, boUsers.Location, boUsers.Reputation, boUsers.UpVotes, boUsers.Views, boUsers.WebsiteUrl);

                        return model;
                }

                public virtual List<ApiUsersResponseModel> MapBOToModel(
                        List<BOUsers> items)
                {
                        List<ApiUsersResponseModel> response = new List<ApiUsersResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>4ae31f2f79a0b9fa49cf942f24da55a0</Hash>
</Codenesium>*/