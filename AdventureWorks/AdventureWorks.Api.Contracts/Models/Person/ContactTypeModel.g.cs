using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ContactTypeModel
	{
		public ContactTypeModel()
		{}
		public ContactTypeModel(string name,
		                        DateTime modifiedDate)
		{
			this.Name = name;
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
    <Hash>84debf21c91a64cea755756b76eaf048</Hash>
</Codenesium>*/