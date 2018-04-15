using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class TeamModel
	{
		public TeamModel()
		{}

		public TeamModel(
			string name,
			int organizationId)
		{
			this.Name = name.ToString();
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
    <Hash>61abd5a56c22209e326f2cc7ab8d677e</Hash>
</Codenesium>*/