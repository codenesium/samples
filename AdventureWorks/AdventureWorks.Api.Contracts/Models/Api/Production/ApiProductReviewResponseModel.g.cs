using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductReviewResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string comments,
                        string emailAddress,
                        DateTime modifiedDate,
                        int productID,
                        int productReviewID,
                        int rating,
                        DateTime reviewDate,
                        string reviewerName)
                {
                        this.Comments = comments;
                        this.EmailAddress = emailAddress;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.ProductReviewID = productReviewID;
                        this.Rating = rating;
                        this.ReviewDate = reviewDate;
                        this.ReviewerName = reviewerName;
                }

                public string Comments { get; private set; }

                public string EmailAddress { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public int ProductReviewID { get; private set; }

                public int Rating { get; private set; }

                public DateTime ReviewDate { get; private set; }

                public string ReviewerName { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCommentsValue { get; set; } = true;

                public bool ShouldSerializeComments()
                {
                        return this.ShouldSerializeCommentsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeEmailAddressValue { get; set; } = true;

                public bool ShouldSerializeEmailAddress()
                {
                        return this.ShouldSerializeEmailAddressValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductIDValue { get; set; } = true;

                public bool ShouldSerializeProductID()
                {
                        return this.ShouldSerializeProductIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductReviewIDValue { get; set; } = true;

                public bool ShouldSerializeProductReviewID()
                {
                        return this.ShouldSerializeProductReviewIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRatingValue { get; set; } = true;

                public bool ShouldSerializeRating()
                {
                        return this.ShouldSerializeRatingValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeReviewDateValue { get; set; } = true;

                public bool ShouldSerializeReviewDate()
                {
                        return this.ShouldSerializeReviewDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeReviewerNameValue { get; set; } = true;

                public bool ShouldSerializeReviewerName()
                {
                        return this.ShouldSerializeReviewerNameValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCommentsValue = false;
                        this.ShouldSerializeEmailAddressValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeProductIDValue = false;
                        this.ShouldSerializeProductReviewIDValue = false;
                        this.ShouldSerializeRatingValue = false;
                        this.ShouldSerializeReviewDateValue = false;
                        this.ShouldSerializeReviewerNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>2b0d3a806e8ca66d70e2661961c5a652</Hash>
</Codenesium>*/