using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiIllustrationModel
	{
		public ApiIllustrationModel()
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
    <Hash>f32cd6dfdb8242a26d996e8d610aca8d</Hash>
</Codenesium>*/