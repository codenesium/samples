using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class ApiLessonStatusModel: AbstractModel
	{
		public ApiLessonStatusModel() : base()
		{}

		public ApiLessonStatusModel(
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
    <Hash>013a6bf57453ec6ac2d97af51f7fe293</Hash>
</Codenesium>*/