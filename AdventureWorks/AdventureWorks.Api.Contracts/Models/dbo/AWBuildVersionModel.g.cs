using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class AWBuildVersionModel
	{
		public AWBuildVersionModel()
		{}

		public AWBuildVersionModel(
			string database_Version,
			DateTime versionDate,
			DateTime modifiedDate)
		{
			this.Database_Version = database_Version.ToString();
			this.VersionDate = versionDate.ToDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string database_Version;

		[Required]
		public string Database_Version
		{
			get
			{
				return this.database_Version;
			}

			set
			{
				this.database_Version = value;
			}
		}

		private DateTime versionDate;

		[Required]
		public DateTime VersionDate
		{
			get
			{
				return this.versionDate;
			}

			set
			{
				this.versionDate = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>c4c4dbeea12b094847fb80fa4056f56b</Hash>
</Codenesium>*/