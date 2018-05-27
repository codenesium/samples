using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiIllustrationRequestModel: AbstractApiRequestModel
	{
		public ApiIllustrationRequestModel() : base()
		{}

		public void SetProperties(
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
    <Hash>4643a4e32872ca1a330f29e07e979933</Hash>
</Codenesium>*/