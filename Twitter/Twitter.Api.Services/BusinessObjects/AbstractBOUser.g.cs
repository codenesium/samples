using Codenesium.DataConversionExtensions;
using System;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractBOUser : AbstractBusinessObject
	{
		public AbstractBOUser()
			: base()
		{
		}

		public virtual void SetProperties(int userId,
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

		public string BioImgUrl { get; private set; }

		public DateTime? Birthday { get; private set; }

		public string ContentDescription { get; private set; }

		public string Email { get; private set; }

		public string FullName { get; private set; }

		public string HeaderImgUrl { get; private set; }

		public string Interest { get; private set; }

		public int LocationLocationId { get; private set; }

		public string Password { get; private set; }

		public string PhoneNumber { get; private set; }

		public string Privacy { get; private set; }

		public int UserId { get; private set; }

		public string Username { get; private set; }

		public string Website { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8137d973dc032d953c76963434bf61ca</Hash>
</Codenesium>*/