using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductReview", Schema="Production")]
        public partial class ProductReview : AbstractEntity
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

                [Column("Comments")]
                public string Comments { get; private set; }

                [Column("EmailAddress")]
                public string EmailAddress { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("ProductID")]
                public int ProductID { get; private set; }

                [Key]
                [Column("ProductReviewID")]
                public int ProductReviewID { get; private set; }

                [Column("Rating")]
                public int Rating { get; private set; }

                [Column("ReviewDate")]
                public DateTime ReviewDate { get; private set; }

                [Column("ReviewerName")]
                public string ReviewerName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9b34d186db5b03271748e605d207c397</Hash>
</Codenesium>*/