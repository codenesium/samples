using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace NebulaNS.Api.Contracts
{
	public partial class LinkStatusModel
	{
		public LinkStatusModel()
		{}

		public LinkStatusModel(int id,
		                       string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		public LinkStatusModel(POCOLinkStatus poco)
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
    <Hash>f213303fcb9a64c4ae3783c2389164cf</Hash>
</Codenesium>*/