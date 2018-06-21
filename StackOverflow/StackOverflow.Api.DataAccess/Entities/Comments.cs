using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowNS.Api.DataAccess
{
        [Table("Comments", Schema="dbo")]
        public partial class Comments : AbstractEntity
        {
                public Comments()
                {
                }

                public void SetProperties(
                        DateTime creationDate,
                        int id,
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

                [Column("CreationDate")]
                public DateTime CreationDate { get; private set; }

                [Key]
                [Column("Id")]
                public int Id { get; private set; }

                [Column("PostId")]
                public int PostId { get; private set; }

                [Column("Score")]
                public Nullable<int> Score { get; private set; }

                [Column("Text")]
                public string Text { get; private set; }

                [Column("UserId")]
                public Nullable<int> UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0d29762a3aae70f58ad2b7936a56acf9</Hash>
</Codenesium>*/