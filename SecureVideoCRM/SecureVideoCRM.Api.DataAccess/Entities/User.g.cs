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
			int subscriptionId)
		{
			this.Id = id;
			this.Email = email;
			this.Password = password;
			this.SubscriptionId = subscriptionId;
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

		[Column("subscriptionId")]
		public virtual int SubscriptionId { get; private set; }

		[ForeignKey("SubscriptionId")]
		public virtual Subscription SubscriptionIdNavigation { get; private set; }

		public void SetSubscriptionIdNavigation(Subscription item)
		{
			this.SubscriptionIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>a8c366d5ad8cddb3de1d9b8863a01ab4</Hash>
</Codenesium>*/