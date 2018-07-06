using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostHistoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string comment,
                        DateTime creationDate,
                        int postHistoryTypeId,
                        int postId,
                        string revisionGUID,
                        string text,
                        string userDisplayName,
                        int? userId)
                {
                        this.Id = id;
                        this.Comment = comment;
                        this.CreationDate = creationDate;
                        this.PostHistoryTypeId = postHistoryTypeId;
                        this.PostId = postId;
                        this.RevisionGUID = revisionGUID;
                        this.Text = text;
                        this.UserDisplayName = userDisplayName;
                        this.UserId = userId;
                }

                public string Comment { get; private set; }

                public DateTime CreationDate { get; private set; }

                public int Id { get; private set; }

                public int PostHistoryTypeId { get; private set; }

                public int PostId { get; private set; }

                public string RevisionGUID { get; private set; }

                public string Text { get; private set; }

                public string UserDisplayName { get; private set; }

                public int? UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>33b4aba2ae03158f170eb32052081293</Hash>
</Codenesium>*/