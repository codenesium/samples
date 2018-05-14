using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiAWBuildVersionModel
	{
		public ApiAWBuildVersionModel()
		{}

		public ApiAWBuildVersionModel(
			string database_Version,
			DateTime modifiedDate,
			DateTime versionDate)
		{
			this.Database_Version = database_Version.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.VersionDate = versionDate.ToDateTime();
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
	}
}

/*<Codenesium>
    <Hash>b26dccac720900505b83d8824a05ce39</Hash>
</Codenesium>*/