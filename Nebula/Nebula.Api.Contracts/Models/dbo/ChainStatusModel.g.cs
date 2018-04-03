using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ChainStatusModel
	{
		public ChainStatusModel()
		{}
		public ChainStatusModel(string name)
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
    <Hash>4bad46cb9629e2dd48bbad3c1ffc64f4</Hash>
</Codenesium>*/