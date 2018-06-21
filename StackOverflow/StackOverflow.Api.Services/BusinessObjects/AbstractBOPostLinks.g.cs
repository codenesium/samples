using Codenesium.DataConversionExtensions;
using System;

namespace StackOverflowNS.Api.Services
{
        public abstract class AbstractBOPostLinks : AbstractBusinessObject
        {
                public AbstractBOPostLinks()
                        : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  DateTime creationDate,
                                                  int linkTypeId,
                                                  int postId,
                                                  int relatedPostId)
                {
                        this.CreationDate = creationDate;
                        this.Id = id;
                        this.LinkTypeId = linkTypeId;
                        this.PostId = postId;
                        this.RelatedPostId = relatedPostId;
                }

                public DateTime CreationDate { get; private set; }

                public int Id { get; private set; }

                public int LinkTypeId { get; private set; }

                public int PostId { get; private set; }

                public int RelatedPostId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>21cb00ff8042f156cb26da5862a3215b</Hash>
</Codenesium>*/