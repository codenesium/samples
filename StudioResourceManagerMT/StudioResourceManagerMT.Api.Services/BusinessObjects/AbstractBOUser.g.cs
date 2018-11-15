using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>0921f7971f5633129781165410f8b65f</Hash>
</Codenesium>*/