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

                [JsonIgnore]
                public bool ShouldSerializeCreationDateValue { get; set; } = true;

                public bool ShouldSerializeCreationDate()
                {
                        return this.ShouldSerializeCreationDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLinkTypeIdValue { get; set; } = true;

                public bool ShouldSerializeLinkTypeId()
                {
                        return this.ShouldSerializeLinkTypeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePostIdValue { get; set; } = true;

                public bool ShouldSerializePostId()
                {
                        return this.ShouldSerializePostIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRelatedPostIdValue { get; set; } = true;

                public bool ShouldSerializeRelatedPostId()
                {
                        return this.ShouldSerializeRelatedPostIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCreationDateValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeLinkTypeIdValue = false;
                        this.ShouldSerializePostIdValue = false;
                        this.ShouldSerializeRelatedPostIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>bce419e6009f508fcdda938d06b3209b</Hash>
</Codenesium>*/