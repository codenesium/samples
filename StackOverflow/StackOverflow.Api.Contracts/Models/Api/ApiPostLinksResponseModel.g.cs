using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Contracts
{
        public partial class ApiPostLinksResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        DateTime creationDate,
                        int linkTypeId,
                        int postId,
                        int relatedPostId)
                {
                        this.Id = id;
                        this.CreationDate = creationDate;
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
    <Hash>3778a9e1a90464b63171a0edac3478b2</Hash>
</Codenesium>*/