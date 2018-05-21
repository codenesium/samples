using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiIllustrationModel: AbstractModel
	{
		public ApiIllustrationModel() : base()
		{}

		public ApiIllustrationModel(
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
    <Hash>bfdd83bc94b5367309409c4cd89b81cc</Hash>
</Codenesium>*/