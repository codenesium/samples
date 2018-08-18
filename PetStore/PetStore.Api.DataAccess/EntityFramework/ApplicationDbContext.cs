using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace PetStoreNS.Api.DataAccess
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
    <Hash>856f9e51fb08871ac926e33ba5b2532e</Hash>
</Codenesium>*/