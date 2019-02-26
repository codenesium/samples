using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace SecureVideoCRMNS.Api.DataAccess
{
	public class ApplicationDbContext : AbstractApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9b5370ce1e795292e48b1de085deb9bb</Hash>
</Codenesium>*/