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
			int userId,
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
			string username,
			string website)
		{
			this.UserId = userId;
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
			this.Username = username;
			this.Website = website;
		}

		[MaxLength(32)]
		[Column("bio_img_url")]
		public virtual string BioImgUrl { get; private set; }

		[Column("birthday")]
		public virtual DateTime? Birthday { get; private set; }

		[MaxLength(128)]
		[Column("content_description")]
		public virtual string ContentDescription { get; private set; }

		[MaxLength(32)]
		[Column("email")]
		public virtual string Email { get; private set; }

		[MaxLength(64)]
		[Column("full_name")]
		public virtual string FullName { get; private set; }

		[MaxLength(32)]
		[Column("header_img_url")]
		public virtual string HeaderImgUrl { get; private set; }

		[MaxLength(128)]
		[Column("interest")]
		public virtual string Interest { get; private set; }

		[Column("location_location_id")]
		public virtual int LocationLocationId { get; private set; }

		[MaxLength(32)]
		[Column("password")]
		public virtual string Password { get; private set; }

		[MaxLength(32)]
		[Column("phone_number")]
		public virtual string PhoneNumber { get; private set; }

		[MaxLength(1)]
		[Column("privacy")]
		public virtual string Privacy { get; private set; }

		[Key]
		[Column("user_id")]
		public virtual int UserId { get; private set; }

		[MaxLength(64)]
		[Column("username")]
		public virtual string Username { get; private set; }

		[MaxLength(32)]
		[Column("website")]
		public virtual string Website { get; private set; }

		[ForeignKey("LocationLocationId")]
		public virtual Location LocationLocationIdNavigation { get; private set; }

		public void SetLocationLocationIdNavigation(Location item)
		{
			this.LocationLocationIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>24e6efbba4176e3e802c50bfbe04be2b</Hash>
</Codenesium>*/