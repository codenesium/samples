using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowNS.Api.DataAccess
{
        [Table("PostHistory", Schema="dbo")]
        public partial class PostHistory : AbstractEntity
        {
                public PostHistory()
                {
                }

                public void SetProperties(
                        string comment,
                        DateTime creationDate,
                        int id,
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

                [Column("Comment")]
                public string Comment { get; private set; }

                [Column("CreationDate")]
                public DateTime CreationDate { get; private set; }

                [Key]
                [Column("Id")]
                public int Id { get; private set; }

                [Column("PostHistoryTypeId")]
                public int PostHistoryTypeId { get; private set; }

                [Column("PostId")]
                public int PostId { get; private set; }

                [Column("RevisionGUID")]
                public string RevisionGUID { get; private set; }

                [Column("Text")]
                public string Text { get; private set; }

                [Column("UserDisplayName")]
                public string UserDisplayName { get; private set; }

                [Column("UserId")]
                public Nullable<int> UserId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c6ec9a64e003a988aab9392433ac601c</Hash>
</Codenesium>*/