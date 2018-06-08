using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductReview", Schema="Production")]
        public partial class ProductReview: AbstractEntity
        {
                public ProductReview()
                {
                }

                public void SetProperties(
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

                [Column("Comments", TypeName="nvarchar(3850)")]
                public string Comments { get; private set; }

                [Column("EmailAddress", TypeName="nvarchar(50)")]
                public string EmailAddress { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("ProductID", TypeName="int")]
                public int ProductID { get; private set; }

                [Key]
                [Column("ProductReviewID", TypeName="int")]
                public int ProductReviewID { get; private set; }

                [Column("Rating", TypeName="int")]
                public int Rating { get; private set; }

                [Column("ReviewDate", TypeName="datetime")]
                public DateTime ReviewDate { get; private set; }

                [Column("ReviewerName", TypeName="nvarchar(50)")]
                public string ReviewerName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b8c9163b782067b51118398532eefc28</Hash>
</Codenesium>*/