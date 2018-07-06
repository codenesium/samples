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
                        int productReviewID,
                        string comments,
                        string emailAddress,
                        DateTime modifiedDate,
                        int productID,
                        int rating,
                        DateTime reviewDate,
                        string reviewerName)
                {
                        this.ProductReviewID = productReviewID;
                        this.Comments = comments;
                        this.EmailAddress = emailAddress;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
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
        }
}

/*<Codenesium>
    <Hash>ea7f88df3c42639a191f30440229f5a0</Hash>
</Codenesium>*/