using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiTeamRequestModel: AbstractApiRequestModel
	{
		public ApiTeamRequestModel() : base()
		{}

		public void SetProperties(
			string name,
			int organizationId)
		{
			this.Name = name;
			this.OrganizationId = organizationId.ToInt();
		}

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}

		private int organizationId;

		[Required]
		public int OrganizationId
		{
			get
			{
				return this.organizationId;
			}

			set
			{
				this.organizationId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>6354d064eb0d5e541afbdf240594e14e</Hash>
</Codenesium>*/