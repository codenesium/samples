using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SecureVideoCRMNS.Api.DataAccess
{
	[Table("Video", Schema="dbo")]
	public partial class Video : AbstractEntity
	{
		public Video()
		{
		}

		public virtual void SetProperties(
			int id,
			string description,
			string title,
			string url)
		{
			this.Id = id;
			this.Description = description;
			this.Title = title;
			this.Url = url;
		}

		[MaxLength(4000)]
		[Column("description")]
		public virtual string Description { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("title")]
		public virtual string Title { get; private set; }

		[MaxLength(128)]
		[Column("url")]
		public virtual string Url { get; private set; }
	}
}

/*<Codenesium>
    <Hash>bbbd4b55a33e6b0de555f2da30ac236c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/