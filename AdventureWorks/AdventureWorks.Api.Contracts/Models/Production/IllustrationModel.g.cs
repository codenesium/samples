using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class IllustrationModel
	{
		public IllustrationModel()
		{}

		public IllustrationModel(
			string diagram,
			DateTime modifiedDate)
		{
			this.Diagram = diagram;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string diagram;

		public string Diagram
		{
			get
			{
				return this.diagram.IsEmptyOrZeroOrNull() ? null : this.diagram;
			}

			set
			{
				this.diagram = value;
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
	}
}

/*<Codenesium>
    <Hash>8428885e70811d584bf15b2156d72f1d</Hash>
</Codenesium>*/