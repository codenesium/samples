using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
        public abstract class AbstractBOPostHistory : AbstractBusinessObject
        {
                public AbstractBOPostHistory()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
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
                        this.Id = id;
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

                public Nullable<int> UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c27d42f572fdc5b1bbf77d6116ba84d2</Hash>
</Codenesium>*/