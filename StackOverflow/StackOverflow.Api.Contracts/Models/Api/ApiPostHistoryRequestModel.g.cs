using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostHistoryRequestModel : AbstractApiRequestModel
        {
                public ApiPostHistoryRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string comment,
                        DateTime creationDate,
                        int postHistoryTypeId,
                        int postId,
                        string revisionGUID,
                        string text,
                        string userDisplayName,
                        Nullable<int> userId)
                {
                        this.Comment = comment;
                        this.CreationDate = creationDate;
                        this.PostHistoryTypeId = postHistoryTypeId;
                        this.PostId = postId;
                        this.RevisionGUID = revisionGUID;
                        this.Text = text;
                        this.UserDisplayName = userDisplayName;
                        this.UserId = userId;
                }

                private string comment;

                public string Comment
                {
                        get
                        {
                                return this.comment.IsEmptyOrZeroOrNull() ? null : this.comment;
                        }

                        set
                        {
                                this.comment = value;
                        }
                }

                private DateTime creationDate;

                [Required]
                public DateTime CreationDate
                {
                        get
                        {
                                return this.creationDate;
                        }

                        set
                        {
                                this.creationDate = value;
                        }
                }

                private int postHistoryTypeId;

                [Required]
                public int PostHistoryTypeId
                {
                        get
                        {
                                return this.postHistoryTypeId;
                        }

                        set
                        {
                                this.postHistoryTypeId = value;
                        }
                }

                private int postId;

                [Required]
                public int PostId
                {
                        get
                        {
                                return this.postId;
                        }

                        set
                        {
                                this.postId = value;
                        }
                }

                private string revisionGUID;

                [Required]
                public string RevisionGUID
                {
                        get
                        {
                                return this.revisionGUID;
                        }

                        set
                        {
                                this.revisionGUID = value;
                        }
                }

                private string text;

                public string Text
                {
                        get
                        {
                                return this.text.IsEmptyOrZeroOrNull() ? null : this.text;
                        }

                        set
                        {
                                this.text = value;
                        }
                }

                private string userDisplayName;

                public string UserDisplayName
                {
                        get
                        {
                                return this.userDisplayName.IsEmptyOrZeroOrNull() ? null : this.userDisplayName;
                        }

                        set
                        {
                                this.userDisplayName = value;
                        }
                }

                private Nullable<int> userId;

                public Nullable<int> UserId
                {
                        get
                        {
                                return this.userId.IsEmptyOrZeroOrNull() ? null : this.userId;
                        }

                        set
                        {
                                this.userId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a7159ba6549be4ed76992fe5200fe3d1</Hash>
</Codenesium>*/