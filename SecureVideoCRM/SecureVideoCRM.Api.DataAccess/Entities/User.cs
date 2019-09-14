using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SecureVideoCRMNS.Api.DataAccess
{
	[Table("User", Schema="dbo")]
	public partial class User : AbstractEntity
	{
		public User()
		{
		}

		public virtual void SetProperties(
			int id,
			string email,
			string password,
			string stripeCustomerId,
			int subscriptionTypeId)
		{
			this.Id = id;
			this.Email = email;
			this.Password = password;
			this.StripeCustomerId = stripeCustomerId;
			this.SubscriptionTypeId = subscriptionTypeId;
		}

		[MaxLength(128)]
		[Column("email")]
		public virtual string Email { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("password")]
		public virtual string Password { get; private set; }

		[MaxLength(128)]
		[Column("stripeCustomerId")]
		public virtual string StripeCustomerId { get; private set; }

		[Column("subscriptionTypeId")]
		public virtual int SubscriptionTypeId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e65f720d24f199c78961fa497c36450d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/