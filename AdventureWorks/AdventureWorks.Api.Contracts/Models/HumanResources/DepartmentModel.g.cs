using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class DepartmentModel
	{
		public DepartmentModel()
		{}
		public DepartmentModel(string name,
		                       string groupName,
		                       DateTime modifiedDate)
		{
			this.Name = name;
			this.GroupName = groupName;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string _name;
		[Required]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				this._name = value;
			}
		}

		private string _groupName;
		[Required]
		public string GroupName
		{
			get
			{
				return _groupName;
			}
			set
			{
				this._groupName = value;
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
    <Hash>7341b31c0a58e77cb5a7b4fb0824479f</Hash>
</Codenesium>*/