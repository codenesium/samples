using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiSpaceFeatureRequestModel: AbstractApiRequestModel
	{
		public ApiSpaceFeatureRequestModel() : base()
		{}

		public void SetProperties(
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
    <Hash>c5e02b9312c59cb71965b5cf32590adb</Hash>
</Codenesium>*/