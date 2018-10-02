using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterNS.Api.DataAccess
{
	[Table("User", Schema="dbo")]
	public partial class User : AbstractEntity
	{
		public User()
		{
		}

		public virtual void SetProperties(
			string bioImgUrl,
			DateTime? birthday,
			string contentDescription,
			string email,
			string fullName,
			string headerImgUrl,
			string interest,
			int locationLocationId,
			string password,
			string phoneNumber,
			string privacy,
			int userId,
			string username,
			string website)
		{
			this.BioImgUrl = bioImgUrl;
			this.Birthday = birthday;
			this.ContentDescription = contentDescription;
			this.Email = email;
			this.FullName = fullName;
			this.HeaderImgUrl = headerImgUrl;
			this.Interest = interest;
			this.LocationLocationId = locationLocationId;
			this.Password = password;
			this.PhoneNumber = phoneNumber;
			this.Privacy = privacy;
			this.UserId = userId;
			this.Username = username;
			this.Website = website;
		}

		[MaxLength(32)]
		[Column("bio_img_url")]
		public string BioImgUrl { get; private set; }

		[Column("birthday")]
		public DateTime? Birthday { get; private set; }

		[MaxLength(128)]
		[Column("content_description")]
		public string ContentDescription { get; private set; }

		[MaxLength(32)]
		[Column("email")]
		public string Email { get; private set; }

		[MaxLength(64)]
		[Column("full_name")]
		public string FullName { get; private set; }

		[MaxLength(32)]
		[Column("header_img_url")]
		public string HeaderImgUrl { get; private set; }

		[MaxLength(128)]
		[Column("interest")]
		public string Interest { get; private set; }

		[Column("location_location_id")]
		public int LocationLocationId { get; private set; }

		[MaxLength(32)]
		[Column("password")]
		public string Password { get; private set; }

		[MaxLength(32)]
		[Column("phone_number")]
		public string PhoneNumber { get; private set; }

		[MaxLength(1)]
		[Column("privacy")]
		public string Privacy { get; private set; }

		[Key]
		[Column("user_id")]
		public int UserId { get; private set; }

		[MaxLength(64)]
		[Column("username")]
		public string Username { get; private set; }

		[MaxLength(32)]
		[Column("website")]
		public string Website { get; private set; }

		[ForeignKey("LocationLocationId")]
		public virtual Location LocationNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>98afe2b76c880ae9fdbdb7110ef1d768</Hash>
</Codenesium>*/