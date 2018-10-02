using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractBOUser : AbstractBusinessObject
	{
		public AbstractBOUser()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string password,
		                                  string username)
		{
			this.Id = id;
			this.Password = password;
			this.Username = username;
		}

		public int Id { get; private set; }

		public string Password { get; private set; }

		public string Username { get; private set; }
	}
}

/*<Codenesium>
    <Hash>732c76bce57dc3bf337f979f95cfe4ab</Hash>
</Codenesium>*/