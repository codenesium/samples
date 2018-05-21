using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiSpaceFeatureModel: AbstractModel
	{
		public ApiSpaceFeatureModel() : base()
		{}

		public ApiSpaceFeatureModel(
			string name,
			int studioId)
		{
			this.Name = name;
			this.StudioId = studioId.ToInt();
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

		private int studioId;

		[Required]
		public int StudioId
		{
			get
			{
				return this.studioId;
			}

			set
			{
				this.studioId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>9f7477e3b4be8cde7cbf8ad10381e6f0</Hash>
</Codenesium>*/