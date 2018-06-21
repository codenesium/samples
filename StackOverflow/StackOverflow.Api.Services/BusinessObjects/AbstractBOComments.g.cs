using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
        public abstract class AbstractBOComments : AbstractBusinessObject
        {
                public AbstractBOComments()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  DateTime creationDate,
                                                  int postId,
                                                  Nullable<int> score,
                                                  string text,
                                                  Nullable<int> userId)
                {
                        this.CreationDate = creationDate;
                        this.Id = id;
                        this.PostId = postId;
                        this.Score = score;
                        this.Text = text;
                        this.UserId = userId;
                }

                public DateTime CreationDate { get; private set; }

                public int Id { get; private set; }

                public int PostId { get; private set; }

                public Nullable<int> Score { get; private set; }

                public string Text { get; private set; }

                public Nullable<int> UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ccccb6314cfca0f6ce6a8176c6f17bae</Hash>
</Codenesium>*/