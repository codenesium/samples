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
		                                  string username,
		                                  bool isDeleted)
		{
			this.Id = id;
			this.Password = password;
			this.Username = username;
			this.IsDeleted = isDeleted;
		}

		public int Id { get; private set; }

		public string Password { get; private set; }

		public string Username { get; private set; }

		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>217e8d77bd17d3a2a89bf7471a0f2200</Hash>
</Codenesium>*/