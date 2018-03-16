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

		public FileTypeModel(POCOFileType poco)
		{
			this.Name = poco.Name;
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
    <Hash>c8b7893c810ed9f19d88b32ff2aefb64</Hash>
</Codenesium>*/