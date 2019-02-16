using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterNS.Api.DataAccess
{
	[Table("Following", Schema="dbo")]
	public partial class Following : AbstractEntity
	{
		public Following()
		{
		}

		public virtual void SetProperties(
			int userId,
			DateTime? dateFollowed,
			string muted)
		{
			this.UserId = userId;
			this.DateFollowed = dateFollowed;
			this.Muted = muted;
		}

		[Column("date_followed")]
		public virtual DateTime? DateFollowed { get; private set; }

		[MaxLength(1)]
		[Column("muted")]
		public virtual string Muted { get; private set; }

		[Key]
		[Column("user_id")]
		public virtual int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>05d3ea279c03afe06b082ade26fade74</Hash>
</Codenesium>*/