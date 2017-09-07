using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace FileServiceNS.Api.Contracts
{
	public partial class FileTypeModel
	{
		public FileTypeModel()
		{}

		public FileTypeModel(int id,
		                     string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public FileTypeModel(POCOFileType poco)
		{
			this.Id = poco.Id.ToInt();
			this.Name = poco.Name;
		}

		private int _id;
		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				this._id = value;
			}
		}

		private string _name;
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
    <Hash>e103ceafc02c894745318c88cae0d044</Hash>
</Codenesium>*/