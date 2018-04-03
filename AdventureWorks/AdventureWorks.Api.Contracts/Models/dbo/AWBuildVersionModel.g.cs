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
		public AWBuildVersionModel(string database_Version,
		                           DateTime versionDate,
		                           DateTime modifiedDate)
		{
			this.Database_Version = database_Version;
			this.VersionDate = versionDate.ToDateTime();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string _database_Version;
		[Required]
		public string Database_Version
		{
			get
			{
				return _database_Version;
			}
			set
			{
				this._database_Version = value;
			}
		}

		private DateTime _versionDate;
		[Required]
		public DateTime VersionDate
		{
			get
			{
				return _versionDate;
			}
			set
			{
				this._versionDate = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>87ac2c3a7f5293eef9e502c44b2d477d</Hash>
</Codenesium>*/