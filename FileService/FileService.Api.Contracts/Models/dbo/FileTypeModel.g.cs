using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FileServiceNS.Api.Contracts
{
	public partial class FileTypeModel
	{
		public FileTypeModel()
		{}
		public FileTypeModel(string name)
		{
			this.Name = name;
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
	}
}

/*<Codenesium>
    <Hash>a7805644ce499458e3ded54ccad30d89</Hash>
</Codenesium>*/