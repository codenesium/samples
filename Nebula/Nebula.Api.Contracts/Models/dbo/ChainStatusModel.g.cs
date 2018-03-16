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

		public ChainStatusModel(POCOChainStatus poco)
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
    <Hash>d28223e15c9a7b5d9f838798130d73c7</Hash>
</Codenesium>*/