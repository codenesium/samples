using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOProductPhoto: AbstractBOProductPhoto, IBOProductPhoto
	{
		public BOProductPhoto(
			ILogger<ProductPhotoRepository> logger,
			IProductPhotoRepository productPhotoRepository,
			IProductPhotoModelValidator productPhotoModelValidator)
			: base(logger, productPhotoRepository, productPhotoModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>885e04d00691e15d402657a83b640940</Hash>
</Codenesium>*/