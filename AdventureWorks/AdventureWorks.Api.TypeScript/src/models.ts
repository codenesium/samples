export class ApiAWBuildVersionClientRequestModel {
	database_Version : string;
	modifiedDate : any;
	systemInformationID : number;
	versionDate : any;

	constructor() {
		this.database_Version = '';
		this.modifiedDate = null;
		this.systemInformationID = 0;
		this.versionDate = null;
	}
}

export class ApiAWBuildVersionClientResponseModel {
	database_Version : string;
	modifiedDate : any;
	systemInformationID : number;
	versionDate : any;

	constructor() {
		this.database_Version = '';
		this.modifiedDate = null;
		this.systemInformationID = 0;
		this.versionDate = null;
	}
}
export class ApiDatabaseLogClientRequestModel {
	databaseLogID : number;
	databaseUser : string;
	event: string;
	object: string;
	postTime : any;
	schema : string;
	tsql : string;
	xmlEvent : string;

	constructor() {
		this.databaseLogID = 0;
		this.databaseUser = '';
		this.event = '';
		this.object = '';
		this.postTime = null;
		this.schema = '';
		this.tsql = '';
		this.xmlEvent = '';
	}
}

export class ApiDatabaseLogClientResponseModel {
	databaseLogID : number;
	databaseUser : string;
	event: string;
	object: string;
	postTime : any;
	schema : string;
	tsql : string;
	xmlEvent : string;

	constructor() {
		this.databaseLogID = 0;
		this.databaseUser = '';
		this.event = '';
		this.object = '';
		this.postTime = null;
		this.schema = '';
		this.tsql = '';
		this.xmlEvent = '';
	}
}
export class ApiErrorLogClientRequestModel {
	errorLine : any;
	errorLogID : number;
	errorMessage : string;
	errorNumber : number;
	errorProcedure : string;
	errorSeverity : any;
	errorState : any;
	errorTime : any;
	userName : string;

	constructor() {
		this.errorLine = null;
		this.errorLogID = 0;
		this.errorMessage = '';
		this.errorNumber = 0;
		this.errorProcedure = '';
		this.errorSeverity = null;
		this.errorState = null;
		this.errorTime = null;
		this.userName = '';
	}
}

export class ApiErrorLogClientResponseModel {
	errorLine : any;
	errorLogID : number;
	errorMessage : string;
	errorNumber : number;
	errorProcedure : string;
	errorSeverity : any;
	errorState : any;
	errorTime : any;
	userName : string;

	constructor() {
		this.errorLine = null;
		this.errorLogID = 0;
		this.errorMessage = '';
		this.errorNumber = 0;
		this.errorProcedure = '';
		this.errorSeverity = null;
		this.errorState = null;
		this.errorTime = null;
		this.userName = '';
	}
}
export class ApiDepartmentClientRequestModel {
	departmentID : number;
	groupName : string;
	modifiedDate : any;
	name : string;

	constructor() {
		this.departmentID = 0;
		this.groupName = '';
		this.modifiedDate = null;
		this.name = '';
	}
}

export class ApiDepartmentClientResponseModel {
	departmentID : number;
	groupName : string;
	modifiedDate : any;
	name : string;

	constructor() {
		this.departmentID = 0;
		this.groupName = '';
		this.modifiedDate = null;
		this.name = '';
	}
}
export class ApiEmployeeClientRequestModel {
	birthDate : any;
	businessEntityID : number;
	currentFlag : boolean;
	gender : string;
	hireDate : any;
	jobTitle : string;
	loginID : string;
	maritalStatu : string;
	modifiedDate : any;
	nationalIDNumber : string;
	organizationLevel : any;
	rowguid : any;
	salariedFlag : boolean;
	sickLeaveHour : number;
	vacationHour : number;

	constructor() {
		this.birthDate = null;
		this.businessEntityID = 0;
		this.currentFlag = false;
		this.gender = '';
		this.hireDate = null;
		this.jobTitle = '';
		this.loginID = '';
		this.maritalStatu = '';
		this.modifiedDate = null;
		this.nationalIDNumber = '';
		this.organizationLevel = null;
		this.rowguid = null;
		this.salariedFlag = false;
		this.sickLeaveHour = 0;
		this.vacationHour = 0;
	}
}

export class ApiEmployeeClientResponseModel {
	birthDate : any;
	businessEntityID : number;
	currentFlag : boolean;
	gender : string;
	hireDate : any;
	jobTitle : string;
	loginID : string;
	maritalStatu : string;
	modifiedDate : any;
	nationalIDNumber : string;
	organizationLevel : any;
	rowguid : any;
	salariedFlag : boolean;
	sickLeaveHour : number;
	vacationHour : number;

	constructor() {
		this.birthDate = null;
		this.businessEntityID = 0;
		this.currentFlag = false;
		this.gender = '';
		this.hireDate = null;
		this.jobTitle = '';
		this.loginID = '';
		this.maritalStatu = '';
		this.modifiedDate = null;
		this.nationalIDNumber = '';
		this.organizationLevel = null;
		this.rowguid = null;
		this.salariedFlag = false;
		this.sickLeaveHour = 0;
		this.vacationHour = 0;
	}
}
export class ApiJobCandidateClientRequestModel {
	businessEntityID : any;
	jobCandidateID : number;
	modifiedDate : any;
	resume : string;

	constructor() {
		this.businessEntityID = null;
		this.jobCandidateID = 0;
		this.modifiedDate = null;
		this.resume = '';
	}
}

export class ApiJobCandidateClientResponseModel {
	businessEntityID : any;
	jobCandidateID : number;
	modifiedDate : any;
	resume : string;

	constructor() {
		this.businessEntityID = null;
		this.jobCandidateID = 0;
		this.modifiedDate = null;
		this.resume = '';
	}
}
export class ApiShiftClientRequestModel {
	endTime : any;
	modifiedDate : any;
	name : string;
	shiftID : number;
	startTime : any;

	constructor() {
		this.endTime = null;
		this.modifiedDate = null;
		this.name = '';
		this.shiftID = 0;
		this.startTime = null;
	}
}

export class ApiShiftClientResponseModel {
	endTime : any;
	modifiedDate : any;
	name : string;
	shiftID : number;
	startTime : any;

	constructor() {
		this.endTime = null;
		this.modifiedDate = null;
		this.name = '';
		this.shiftID = 0;
		this.startTime = null;
	}
}
export class ApiAddressClientRequestModel {
	addressID : number;
	addressLine1 : string;
	addressLine2 : string;
	city : string;
	modifiedDate : any;
	postalCode : string;
	rowguid : any;
	stateProvinceID : number;

	constructor() {
		this.addressID = 0;
		this.addressLine1 = '';
		this.addressLine2 = '';
		this.city = '';
		this.modifiedDate = null;
		this.postalCode = '';
		this.rowguid = null;
		this.stateProvinceID = 0;
	}
}

export class ApiAddressClientResponseModel {
	addressID : number;
	addressLine1 : string;
	addressLine2 : string;
	city : string;
	modifiedDate : any;
	postalCode : string;
	rowguid : any;
	stateProvinceID : number;

	constructor() {
		this.addressID = 0;
		this.addressLine1 = '';
		this.addressLine2 = '';
		this.city = '';
		this.modifiedDate = null;
		this.postalCode = '';
		this.rowguid = null;
		this.stateProvinceID = 0;
	}
}
export class ApiAddressTypeClientRequestModel {
	addressTypeID : number;
	modifiedDate : any;
	name : string;
	rowguid : any;

	constructor() {
		this.addressTypeID = 0;
		this.modifiedDate = null;
		this.name = '';
		this.rowguid = null;
	}
}

export class ApiAddressTypeClientResponseModel {
	addressTypeID : number;
	modifiedDate : any;
	name : string;
	rowguid : any;

	constructor() {
		this.addressTypeID = 0;
		this.modifiedDate = null;
		this.name = '';
		this.rowguid = null;
	}
}
export class ApiBusinessEntityClientRequestModel {
	businessEntityID : number;
	modifiedDate : any;
	rowguid : any;

	constructor() {
		this.businessEntityID = 0;
		this.modifiedDate = null;
		this.rowguid = null;
	}
}

export class ApiBusinessEntityClientResponseModel {
	businessEntityID : number;
	modifiedDate : any;
	rowguid : any;

	constructor() {
		this.businessEntityID = 0;
		this.modifiedDate = null;
		this.rowguid = null;
	}
}
export class ApiContactTypeClientRequestModel {
	contactTypeID : number;
	modifiedDate : any;
	name : string;

	constructor() {
		this.contactTypeID = 0;
		this.modifiedDate = null;
		this.name = '';
	}
}

export class ApiContactTypeClientResponseModel {
	contactTypeID : number;
	modifiedDate : any;
	name : string;

	constructor() {
		this.contactTypeID = 0;
		this.modifiedDate = null;
		this.name = '';
	}
}
export class ApiCountryRegionClientRequestModel {
	countryRegionCode : string;
	modifiedDate : any;
	name : string;

	constructor() {
		this.countryRegionCode = '';
		this.modifiedDate = null;
		this.name = '';
	}
}

export class ApiCountryRegionClientResponseModel {
	countryRegionCode : string;
	modifiedDate : any;
	name : string;

	constructor() {
		this.countryRegionCode = '';
		this.modifiedDate = null;
		this.name = '';
	}
}
export class ApiPasswordClientRequestModel {
	businessEntityID : number;
	modifiedDate : any;
	passwordHash : string;
	passwordSalt : string;
	rowguid : any;

	constructor() {
		this.businessEntityID = 0;
		this.modifiedDate = null;
		this.passwordHash = '';
		this.passwordSalt = '';
		this.rowguid = null;
	}
}

export class ApiPasswordClientResponseModel {
	businessEntityID : number;
	modifiedDate : any;
	passwordHash : string;
	passwordSalt : string;
	rowguid : any;

	constructor() {
		this.businessEntityID = 0;
		this.modifiedDate = null;
		this.passwordHash = '';
		this.passwordSalt = '';
		this.rowguid = null;
	}
}
export class ApiPersonClientRequestModel {
	additionalContactInfo : string;
	businessEntityID : number;
	demographic : string;
	emailPromotion : number;
	firstName : string;
	lastName : string;
	middleName : string;
	modifiedDate : any;
	nameStyle : boolean;
	personType : string;
	rowguid : any;
	suffix : string;
	title : string;

	constructor() {
		this.additionalContactInfo = '';
		this.businessEntityID = 0;
		this.demographic = '';
		this.emailPromotion = 0;
		this.firstName = '';
		this.lastName = '';
		this.middleName = '';
		this.modifiedDate = null;
		this.nameStyle = false;
		this.personType = '';
		this.rowguid = null;
		this.suffix = '';
		this.title = '';
	}
}

export class ApiPersonClientResponseModel {
	additionalContactInfo : string;
	businessEntityID : number;
	demographic : string;
	emailPromotion : number;
	firstName : string;
	lastName : string;
	middleName : string;
	modifiedDate : any;
	nameStyle : boolean;
	personType : string;
	rowguid : any;
	suffix : string;
	title : string;

	constructor() {
		this.additionalContactInfo = '';
		this.businessEntityID = 0;
		this.demographic = '';
		this.emailPromotion = 0;
		this.firstName = '';
		this.lastName = '';
		this.middleName = '';
		this.modifiedDate = null;
		this.nameStyle = false;
		this.personType = '';
		this.rowguid = null;
		this.suffix = '';
		this.title = '';
	}
}
export class ApiPhoneNumberTypeClientRequestModel {
	modifiedDate : any;
	name : string;
	phoneNumberTypeID : number;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.phoneNumberTypeID = 0;
	}
}

export class ApiPhoneNumberTypeClientResponseModel {
	modifiedDate : any;
	name : string;
	phoneNumberTypeID : number;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.phoneNumberTypeID = 0;
	}
}
export class ApiStateProvinceClientRequestModel {
	countryRegionCode : string;
	isOnlyStateProvinceFlag : boolean;
	modifiedDate : any;
	name : string;
	rowguid : any;
	stateProvinceCode : string;
	stateProvinceID : number;
	territoryID : number;

	constructor() {
		this.countryRegionCode = '';
		this.isOnlyStateProvinceFlag = false;
		this.modifiedDate = null;
		this.name = '';
		this.rowguid = null;
		this.stateProvinceCode = '';
		this.stateProvinceID = 0;
		this.territoryID = 0;
	}
}

export class ApiStateProvinceClientResponseModel {
	countryRegionCode : string;
	isOnlyStateProvinceFlag : boolean;
	modifiedDate : any;
	name : string;
	rowguid : any;
	stateProvinceCode : string;
	stateProvinceID : number;
	territoryID : number;

	constructor() {
		this.countryRegionCode = '';
		this.isOnlyStateProvinceFlag = false;
		this.modifiedDate = null;
		this.name = '';
		this.rowguid = null;
		this.stateProvinceCode = '';
		this.stateProvinceID = 0;
		this.territoryID = 0;
	}
}
export class ApiBillOfMaterialClientRequestModel {
	billOfMaterialsID : number;
	bOMLevel : number;
	componentID : number;
	endDate : any;
	modifiedDate : any;
	perAssemblyQty : number;
	productAssemblyID : any;
	startDate : any;
	unitMeasureCode : string;

	constructor() {
		this.billOfMaterialsID = 0;
		this.bOMLevel = 0;
		this.componentID = 0;
		this.endDate = null;
		this.modifiedDate = null;
		this.perAssemblyQty = 0;
		this.productAssemblyID = null;
		this.startDate = null;
		this.unitMeasureCode = '';
	}
}

export class ApiBillOfMaterialClientResponseModel {
	billOfMaterialsID : number;
	bOMLevel : number;
	componentID : number;
	endDate : any;
	modifiedDate : any;
	perAssemblyQty : number;
	productAssemblyID : any;
	startDate : any;
	unitMeasureCode : string;

	constructor() {
		this.billOfMaterialsID = 0;
		this.bOMLevel = 0;
		this.componentID = 0;
		this.endDate = null;
		this.modifiedDate = null;
		this.perAssemblyQty = 0;
		this.productAssemblyID = null;
		this.startDate = null;
		this.unitMeasureCode = '';
	}
}
export class ApiCultureClientRequestModel {
	cultureID : string;
	modifiedDate : any;
	name : string;

	constructor() {
		this.cultureID = '';
		this.modifiedDate = null;
		this.name = '';
	}
}

export class ApiCultureClientResponseModel {
	cultureID : string;
	modifiedDate : any;
	name : string;

	constructor() {
		this.cultureID = '';
		this.modifiedDate = null;
		this.name = '';
	}
}
export class ApiDocumentClientRequestModel {
	changeNumber : number;
	document1 : any;
	documentLevel : any;
	documentSummary : string;
	fileExtension : string;
	fileName : string;
	folderFlag : boolean;
	modifiedDate : any;
	owner : number;
	revision : string;
	rowguid : any;
	status : number;
	title : string;

	constructor() {
		this.changeNumber = 0;
		this.document1 = null;
		this.documentLevel = null;
		this.documentSummary = '';
		this.fileExtension = '';
		this.fileName = '';
		this.folderFlag = false;
		this.modifiedDate = null;
		this.owner = 0;
		this.revision = '';
		this.rowguid = null;
		this.status = 0;
		this.title = '';
	}
}

export class ApiDocumentClientResponseModel {
	changeNumber : number;
	document1 : any;
	documentLevel : any;
	documentSummary : string;
	fileExtension : string;
	fileName : string;
	folderFlag : boolean;
	modifiedDate : any;
	owner : number;
	revision : string;
	rowguid : any;
	status : number;
	title : string;

	constructor() {
		this.changeNumber = 0;
		this.document1 = null;
		this.documentLevel = null;
		this.documentSummary = '';
		this.fileExtension = '';
		this.fileName = '';
		this.folderFlag = false;
		this.modifiedDate = null;
		this.owner = 0;
		this.revision = '';
		this.rowguid = null;
		this.status = 0;
		this.title = '';
	}
}
export class ApiIllustrationClientRequestModel {
	diagram : string;
	illustrationID : number;
	modifiedDate : any;

	constructor() {
		this.diagram = '';
		this.illustrationID = 0;
		this.modifiedDate = null;
	}
}

export class ApiIllustrationClientResponseModel {
	diagram : string;
	illustrationID : number;
	modifiedDate : any;

	constructor() {
		this.diagram = '';
		this.illustrationID = 0;
		this.modifiedDate = null;
	}
}
export class ApiLocationClientRequestModel {
	availability : number;
	costRate : number;
	locationID : number;
	modifiedDate : any;
	name : string;

	constructor() {
		this.availability = 0;
		this.costRate = 0;
		this.locationID = 0;
		this.modifiedDate = null;
		this.name = '';
	}
}

export class ApiLocationClientResponseModel {
	availability : number;
	costRate : number;
	locationID : number;
	modifiedDate : any;
	name : string;

	constructor() {
		this.availability = 0;
		this.costRate = 0;
		this.locationID = 0;
		this.modifiedDate = null;
		this.name = '';
	}
}
export class ApiProductClientRequestModel {
	class : string;
	color : string;
	daysToManufacture : number;
	discontinuedDate : any;
	finishedGoodsFlag : boolean;
	listPrice : number;
	makeFlag : boolean;
	modifiedDate : any;
	name : string;
	productID : number;
	productLine : string;
	productModelID : any;
	productNumber : string;
	productSubcategoryID : any;
	reorderPoint : number;
	rowguid : any;
	safetyStockLevel : number;
	sellEndDate : any;
	sellStartDate : any;
	size : string;
	sizeUnitMeasureCode : string;
	standardCost : number;
	style : string;
	weight : any;
	weightUnitMeasureCode : string;

	constructor() {
		this.class = '';
		this.color = '';
		this.daysToManufacture = 0;
		this.discontinuedDate = null;
		this.finishedGoodsFlag = false;
		this.listPrice = 0;
		this.makeFlag = false;
		this.modifiedDate = null;
		this.name = '';
		this.productID = 0;
		this.productLine = '';
		this.productModelID = null;
		this.productNumber = '';
		this.productSubcategoryID = null;
		this.reorderPoint = 0;
		this.rowguid = null;
		this.safetyStockLevel = 0;
		this.sellEndDate = null;
		this.sellStartDate = null;
		this.size = '';
		this.sizeUnitMeasureCode = '';
		this.standardCost = 0;
		this.style = '';
		this.weight = null;
		this.weightUnitMeasureCode = '';
	}
}

export class ApiProductClientResponseModel {
	class : string;
	color : string;
	daysToManufacture : number;
	discontinuedDate : any;
	finishedGoodsFlag : boolean;
	listPrice : number;
	makeFlag : boolean;
	modifiedDate : any;
	name : string;
	productID : number;
	productLine : string;
	productModelID : any;
	productNumber : string;
	productSubcategoryID : any;
	reorderPoint : number;
	rowguid : any;
	safetyStockLevel : number;
	sellEndDate : any;
	sellStartDate : any;
	size : string;
	sizeUnitMeasureCode : string;
	standardCost : number;
	style : string;
	weight : any;
	weightUnitMeasureCode : string;

	constructor() {
		this.class = '';
		this.color = '';
		this.daysToManufacture = 0;
		this.discontinuedDate = null;
		this.finishedGoodsFlag = false;
		this.listPrice = 0;
		this.makeFlag = false;
		this.modifiedDate = null;
		this.name = '';
		this.productID = 0;
		this.productLine = '';
		this.productModelID = null;
		this.productNumber = '';
		this.productSubcategoryID = null;
		this.reorderPoint = 0;
		this.rowguid = null;
		this.safetyStockLevel = 0;
		this.sellEndDate = null;
		this.sellStartDate = null;
		this.size = '';
		this.sizeUnitMeasureCode = '';
		this.standardCost = 0;
		this.style = '';
		this.weight = null;
		this.weightUnitMeasureCode = '';
	}
}
export class ApiProductCategoryClientRequestModel {
	modifiedDate : any;
	name : string;
	productCategoryID : number;
	rowguid : any;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.productCategoryID = 0;
		this.rowguid = null;
	}
}

export class ApiProductCategoryClientResponseModel {
	modifiedDate : any;
	name : string;
	productCategoryID : number;
	rowguid : any;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.productCategoryID = 0;
		this.rowguid = null;
	}
}
export class ApiProductDescriptionClientRequestModel {
	description : string;
	modifiedDate : any;
	productDescriptionID : number;
	rowguid : any;

	constructor() {
		this.description = '';
		this.modifiedDate = null;
		this.productDescriptionID = 0;
		this.rowguid = null;
	}
}

export class ApiProductDescriptionClientResponseModel {
	description : string;
	modifiedDate : any;
	productDescriptionID : number;
	rowguid : any;

	constructor() {
		this.description = '';
		this.modifiedDate = null;
		this.productDescriptionID = 0;
		this.rowguid = null;
	}
}
export class ApiProductModelClientRequestModel {
	catalogDescription : string;
	instruction : string;
	modifiedDate : any;
	name : string;
	productModelID : number;
	rowguid : any;

	constructor() {
		this.catalogDescription = '';
		this.instruction = '';
		this.modifiedDate = null;
		this.name = '';
		this.productModelID = 0;
		this.rowguid = null;
	}
}

export class ApiProductModelClientResponseModel {
	catalogDescription : string;
	instruction : string;
	modifiedDate : any;
	name : string;
	productModelID : number;
	rowguid : any;

	constructor() {
		this.catalogDescription = '';
		this.instruction = '';
		this.modifiedDate = null;
		this.name = '';
		this.productModelID = 0;
		this.rowguid = null;
	}
}
export class ApiProductPhotoClientRequestModel {
	largePhoto : any;
	largePhotoFileName : string;
	modifiedDate : any;
	productPhotoID : number;
	thumbNailPhoto : any;
	thumbnailPhotoFileName : string;

	constructor() {
		this.largePhoto = null;
		this.largePhotoFileName = '';
		this.modifiedDate = null;
		this.productPhotoID = 0;
		this.thumbNailPhoto = null;
		this.thumbnailPhotoFileName = '';
	}
}

export class ApiProductPhotoClientResponseModel {
	largePhoto : any;
	largePhotoFileName : string;
	modifiedDate : any;
	productPhotoID : number;
	thumbNailPhoto : any;
	thumbnailPhotoFileName : string;

	constructor() {
		this.largePhoto = null;
		this.largePhotoFileName = '';
		this.modifiedDate = null;
		this.productPhotoID = 0;
		this.thumbNailPhoto = null;
		this.thumbnailPhotoFileName = '';
	}
}
export class ApiProductReviewClientRequestModel {
	comment : string;
	emailAddress : string;
	modifiedDate : any;
	productID : number;
	productReviewID : number;
	rating : number;
	reviewDate : any;
	reviewerName : string;

	constructor() {
		this.comment = '';
		this.emailAddress = '';
		this.modifiedDate = null;
		this.productID = 0;
		this.productReviewID = 0;
		this.rating = 0;
		this.reviewDate = null;
		this.reviewerName = '';
	}
}

export class ApiProductReviewClientResponseModel {
	comment : string;
	emailAddress : string;
	modifiedDate : any;
	productID : number;
	productReviewID : number;
	rating : number;
	reviewDate : any;
	reviewerName : string;

	constructor() {
		this.comment = '';
		this.emailAddress = '';
		this.modifiedDate = null;
		this.productID = 0;
		this.productReviewID = 0;
		this.rating = 0;
		this.reviewDate = null;
		this.reviewerName = '';
	}
}
export class ApiProductSubcategoryClientRequestModel {
	modifiedDate : any;
	name : string;
	productCategoryID : number;
	productSubcategoryID : number;
	rowguid : any;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.productCategoryID = 0;
		this.productSubcategoryID = 0;
		this.rowguid = null;
	}
}

export class ApiProductSubcategoryClientResponseModel {
	modifiedDate : any;
	name : string;
	productCategoryID : number;
	productSubcategoryID : number;
	rowguid : any;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.productCategoryID = 0;
		this.productSubcategoryID = 0;
		this.rowguid = null;
	}
}
export class ApiScrapReasonClientRequestModel {
	modifiedDate : any;
	name : string;
	scrapReasonID : number;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.scrapReasonID = 0;
	}
}

export class ApiScrapReasonClientResponseModel {
	modifiedDate : any;
	name : string;
	scrapReasonID : number;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.scrapReasonID = 0;
	}
}
export class ApiTransactionHistoryClientRequestModel {
	actualCost : number;
	modifiedDate : any;
	productID : number;
	quantity : number;
	referenceOrderID : number;
	referenceOrderLineID : number;
	transactionDate : any;
	transactionID : number;
	transactionType : string;

	constructor() {
		this.actualCost = 0;
		this.modifiedDate = null;
		this.productID = 0;
		this.quantity = 0;
		this.referenceOrderID = 0;
		this.referenceOrderLineID = 0;
		this.transactionDate = null;
		this.transactionID = 0;
		this.transactionType = '';
	}
}

export class ApiTransactionHistoryClientResponseModel {
	actualCost : number;
	modifiedDate : any;
	productID : number;
	quantity : number;
	referenceOrderID : number;
	referenceOrderLineID : number;
	transactionDate : any;
	transactionID : number;
	transactionType : string;

	constructor() {
		this.actualCost = 0;
		this.modifiedDate = null;
		this.productID = 0;
		this.quantity = 0;
		this.referenceOrderID = 0;
		this.referenceOrderLineID = 0;
		this.transactionDate = null;
		this.transactionID = 0;
		this.transactionType = '';
	}
}
export class ApiTransactionHistoryArchiveClientRequestModel {
	actualCost : number;
	modifiedDate : any;
	productID : number;
	quantity : number;
	referenceOrderID : number;
	referenceOrderLineID : number;
	transactionDate : any;
	transactionID : number;
	transactionType : string;

	constructor() {
		this.actualCost = 0;
		this.modifiedDate = null;
		this.productID = 0;
		this.quantity = 0;
		this.referenceOrderID = 0;
		this.referenceOrderLineID = 0;
		this.transactionDate = null;
		this.transactionID = 0;
		this.transactionType = '';
	}
}

export class ApiTransactionHistoryArchiveClientResponseModel {
	actualCost : number;
	modifiedDate : any;
	productID : number;
	quantity : number;
	referenceOrderID : number;
	referenceOrderLineID : number;
	transactionDate : any;
	transactionID : number;
	transactionType : string;

	constructor() {
		this.actualCost = 0;
		this.modifiedDate = null;
		this.productID = 0;
		this.quantity = 0;
		this.referenceOrderID = 0;
		this.referenceOrderLineID = 0;
		this.transactionDate = null;
		this.transactionID = 0;
		this.transactionType = '';
	}
}
export class ApiUnitMeasureClientRequestModel {
	modifiedDate : any;
	name : string;
	unitMeasureCode : string;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.unitMeasureCode = '';
	}
}

export class ApiUnitMeasureClientResponseModel {
	modifiedDate : any;
	name : string;
	unitMeasureCode : string;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.unitMeasureCode = '';
	}
}
export class ApiWorkOrderClientRequestModel {
	dueDate : any;
	endDate : any;
	modifiedDate : any;
	orderQty : number;
	productID : number;
	scrappedQty : number;
	scrapReasonID : any;
	startDate : any;
	stockedQty : number;
	workOrderID : number;

	constructor() {
		this.dueDate = null;
		this.endDate = null;
		this.modifiedDate = null;
		this.orderQty = 0;
		this.productID = 0;
		this.scrappedQty = 0;
		this.scrapReasonID = null;
		this.startDate = null;
		this.stockedQty = 0;
		this.workOrderID = 0;
	}
}

export class ApiWorkOrderClientResponseModel {
	dueDate : any;
	endDate : any;
	modifiedDate : any;
	orderQty : number;
	productID : number;
	scrappedQty : number;
	scrapReasonID : any;
	startDate : any;
	stockedQty : number;
	workOrderID : number;

	constructor() {
		this.dueDate = null;
		this.endDate = null;
		this.modifiedDate = null;
		this.orderQty = 0;
		this.productID = 0;
		this.scrappedQty = 0;
		this.scrapReasonID = null;
		this.startDate = null;
		this.stockedQty = 0;
		this.workOrderID = 0;
	}
}
export class ApiPurchaseOrderHeaderClientRequestModel {
	employeeID : number;
	freight : number;
	modifiedDate : any;
	orderDate : any;
	purchaseOrderID : number;
	revisionNumber : number;
	shipDate : any;
	shipMethodID : number;
	status : number;
	subTotal : number;
	taxAmt : number;
	totalDue : number;
	vendorID : number;

	constructor() {
		this.employeeID = 0;
		this.freight = 0;
		this.modifiedDate = null;
		this.orderDate = null;
		this.purchaseOrderID = 0;
		this.revisionNumber = 0;
		this.shipDate = null;
		this.shipMethodID = 0;
		this.status = 0;
		this.subTotal = 0;
		this.taxAmt = 0;
		this.totalDue = 0;
		this.vendorID = 0;
	}
}

export class ApiPurchaseOrderHeaderClientResponseModel {
	employeeID : number;
	freight : number;
	modifiedDate : any;
	orderDate : any;
	purchaseOrderID : number;
	revisionNumber : number;
	shipDate : any;
	shipMethodID : number;
	status : number;
	subTotal : number;
	taxAmt : number;
	totalDue : number;
	vendorID : number;

	constructor() {
		this.employeeID = 0;
		this.freight = 0;
		this.modifiedDate = null;
		this.orderDate = null;
		this.purchaseOrderID = 0;
		this.revisionNumber = 0;
		this.shipDate = null;
		this.shipMethodID = 0;
		this.status = 0;
		this.subTotal = 0;
		this.taxAmt = 0;
		this.totalDue = 0;
		this.vendorID = 0;
	}
}
export class ApiShipMethodClientRequestModel {
	modifiedDate : any;
	name : string;
	rowguid : any;
	shipBase : number;
	shipMethodID : number;
	shipRate : number;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.rowguid = null;
		this.shipBase = 0;
		this.shipMethodID = 0;
		this.shipRate = 0;
	}
}

export class ApiShipMethodClientResponseModel {
	modifiedDate : any;
	name : string;
	rowguid : any;
	shipBase : number;
	shipMethodID : number;
	shipRate : number;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.rowguid = null;
		this.shipBase = 0;
		this.shipMethodID = 0;
		this.shipRate = 0;
	}
}
export class ApiVendorClientRequestModel {
	accountNumber : string;
	activeFlag : boolean;
	businessEntityID : number;
	creditRating : number;
	modifiedDate : any;
	name : string;
	preferredVendorStatu : boolean;
	purchasingWebServiceURL : string;

	constructor() {
		this.accountNumber = '';
		this.activeFlag = false;
		this.businessEntityID = 0;
		this.creditRating = 0;
		this.modifiedDate = null;
		this.name = '';
		this.preferredVendorStatu = false;
		this.purchasingWebServiceURL = '';
	}
}

export class ApiVendorClientResponseModel {
	accountNumber : string;
	activeFlag : boolean;
	businessEntityID : number;
	creditRating : number;
	modifiedDate : any;
	name : string;
	preferredVendorStatu : boolean;
	purchasingWebServiceURL : string;

	constructor() {
		this.accountNumber = '';
		this.activeFlag = false;
		this.businessEntityID = 0;
		this.creditRating = 0;
		this.modifiedDate = null;
		this.name = '';
		this.preferredVendorStatu = false;
		this.purchasingWebServiceURL = '';
	}
}
export class ApiCreditCardClientRequestModel {
	cardNumber : string;
	cardType : string;
	creditCardID : number;
	expMonth : number;
	expYear : number;
	modifiedDate : any;

	constructor() {
		this.cardNumber = '';
		this.cardType = '';
		this.creditCardID = 0;
		this.expMonth = 0;
		this.expYear = 0;
		this.modifiedDate = null;
	}
}

export class ApiCreditCardClientResponseModel {
	cardNumber : string;
	cardType : string;
	creditCardID : number;
	expMonth : number;
	expYear : number;
	modifiedDate : any;

	constructor() {
		this.cardNumber = '';
		this.cardType = '';
		this.creditCardID = 0;
		this.expMonth = 0;
		this.expYear = 0;
		this.modifiedDate = null;
	}
}
export class ApiCurrencyClientRequestModel {
	currencyCode : string;
	modifiedDate : any;
	name : string;

	constructor() {
		this.currencyCode = '';
		this.modifiedDate = null;
		this.name = '';
	}
}

export class ApiCurrencyClientResponseModel {
	currencyCode : string;
	modifiedDate : any;
	name : string;

	constructor() {
		this.currencyCode = '';
		this.modifiedDate = null;
		this.name = '';
	}
}
export class ApiCurrencyRateClientRequestModel {
	averageRate : number;
	currencyRateDate : any;
	currencyRateID : number;
	endOfDayRate : number;
	fromCurrencyCode : string;
	fromCurrencyCodeEntity : string;
	modifiedDate : any;
	toCurrencyCode : string;
	toCurrencyCodeEntity : string;

	constructor() {
		this.averageRate = 0;
		this.currencyRateDate = null;
		this.currencyRateID = 0;
		this.endOfDayRate = 0;
		this.fromCurrencyCode = '';
		this.fromCurrencyCodeEntity = '';
		this.modifiedDate = null;
		this.toCurrencyCode = '';
		this.toCurrencyCodeEntity = '';
	}
}

export class ApiCurrencyRateClientResponseModel {
	averageRate : number;
	currencyRateDate : any;
	currencyRateID : number;
	endOfDayRate : number;
	fromCurrencyCode : string;
	fromCurrencyCodeEntity : string;
	modifiedDate : any;
	toCurrencyCode : string;
	toCurrencyCodeEntity : string;

	constructor() {
		this.averageRate = 0;
		this.currencyRateDate = null;
		this.currencyRateID = 0;
		this.endOfDayRate = 0;
		this.fromCurrencyCode = '';
		this.fromCurrencyCodeEntity = '';
		this.modifiedDate = null;
		this.toCurrencyCode = '';
		this.toCurrencyCodeEntity = '';
	}
}
export class ApiCustomerClientRequestModel {
	accountNumber : string;
	customerID : number;
	modifiedDate : any;
	personID : any;
	rowguid : any;
	storeID : any;
	storeIDEntity : string;
	territoryID : any;
	territoryIDEntity : string;

	constructor() {
		this.accountNumber = '';
		this.customerID = 0;
		this.modifiedDate = null;
		this.personID = null;
		this.rowguid = null;
		this.storeID = null;
		this.storeIDEntity = '';
		this.territoryID = null;
		this.territoryIDEntity = '';
	}
}

export class ApiCustomerClientResponseModel {
	accountNumber : string;
	customerID : number;
	modifiedDate : any;
	personID : any;
	rowguid : any;
	storeID : any;
	storeIDEntity : string;
	territoryID : any;
	territoryIDEntity : string;

	constructor() {
		this.accountNumber = '';
		this.customerID = 0;
		this.modifiedDate = null;
		this.personID = null;
		this.rowguid = null;
		this.storeID = null;
		this.storeIDEntity = '';
		this.territoryID = null;
		this.territoryIDEntity = '';
	}
}
export class ApiSalesOrderHeaderClientRequestModel {
	accountNumber : string;
	billToAddressID : number;
	comment : string;
	creditCardApprovalCode : string;
	creditCardID : any;
	creditCardIDEntity : string;
	currencyRateID : any;
	currencyRateIDEntity : string;
	customerID : number;
	customerIDEntity : string;
	dueDate : any;
	freight : number;
	modifiedDate : any;
	onlineOrderFlag : boolean;
	orderDate : any;
	purchaseOrderNumber : string;
	revisionNumber : number;
	rowguid : any;
	salesOrderID : number;
	salesOrderNumber : string;
	salesPersonID : any;
	salesPersonIDEntity : string;
	shipDate : any;
	shipMethodID : number;
	shipToAddressID : number;
	status : number;
	subTotal : number;
	taxAmt : number;
	territoryID : any;
	territoryIDEntity : string;
	totalDue : number;

	constructor() {
		this.accountNumber = '';
		this.billToAddressID = 0;
		this.comment = '';
		this.creditCardApprovalCode = '';
		this.creditCardID = null;
		this.creditCardIDEntity = '';
		this.currencyRateID = null;
		this.currencyRateIDEntity = '';
		this.customerID = 0;
		this.customerIDEntity = '';
		this.dueDate = null;
		this.freight = 0;
		this.modifiedDate = null;
		this.onlineOrderFlag = false;
		this.orderDate = null;
		this.purchaseOrderNumber = '';
		this.revisionNumber = 0;
		this.rowguid = null;
		this.salesOrderID = 0;
		this.salesOrderNumber = '';
		this.salesPersonID = null;
		this.salesPersonIDEntity = '';
		this.shipDate = null;
		this.shipMethodID = 0;
		this.shipToAddressID = 0;
		this.status = 0;
		this.subTotal = 0;
		this.taxAmt = 0;
		this.territoryID = null;
		this.territoryIDEntity = '';
		this.totalDue = 0;
	}
}

export class ApiSalesOrderHeaderClientResponseModel {
	accountNumber : string;
	billToAddressID : number;
	comment : string;
	creditCardApprovalCode : string;
	creditCardID : any;
	creditCardIDEntity : string;
	currencyRateID : any;
	currencyRateIDEntity : string;
	customerID : number;
	customerIDEntity : string;
	dueDate : any;
	freight : number;
	modifiedDate : any;
	onlineOrderFlag : boolean;
	orderDate : any;
	purchaseOrderNumber : string;
	revisionNumber : number;
	rowguid : any;
	salesOrderID : number;
	salesOrderNumber : string;
	salesPersonID : any;
	salesPersonIDEntity : string;
	shipDate : any;
	shipMethodID : number;
	shipToAddressID : number;
	status : number;
	subTotal : number;
	taxAmt : number;
	territoryID : any;
	territoryIDEntity : string;
	totalDue : number;

	constructor() {
		this.accountNumber = '';
		this.billToAddressID = 0;
		this.comment = '';
		this.creditCardApprovalCode = '';
		this.creditCardID = null;
		this.creditCardIDEntity = '';
		this.currencyRateID = null;
		this.currencyRateIDEntity = '';
		this.customerID = 0;
		this.customerIDEntity = '';
		this.dueDate = null;
		this.freight = 0;
		this.modifiedDate = null;
		this.onlineOrderFlag = false;
		this.orderDate = null;
		this.purchaseOrderNumber = '';
		this.revisionNumber = 0;
		this.rowguid = null;
		this.salesOrderID = 0;
		this.salesOrderNumber = '';
		this.salesPersonID = null;
		this.salesPersonIDEntity = '';
		this.shipDate = null;
		this.shipMethodID = 0;
		this.shipToAddressID = 0;
		this.status = 0;
		this.subTotal = 0;
		this.taxAmt = 0;
		this.territoryID = null;
		this.territoryIDEntity = '';
		this.totalDue = 0;
	}
}
export class ApiSalesPersonClientRequestModel {
	bonus : number;
	businessEntityID : number;
	commissionPct : number;
	modifiedDate : any;
	rowguid : any;
	salesLastYear : number;
	salesQuota : any;
	salesYTD : number;
	territoryID : any;
	territoryIDEntity : string;

	constructor() {
		this.bonus = 0;
		this.businessEntityID = 0;
		this.commissionPct = 0;
		this.modifiedDate = null;
		this.rowguid = null;
		this.salesLastYear = 0;
		this.salesQuota = null;
		this.salesYTD = 0;
		this.territoryID = null;
		this.territoryIDEntity = '';
	}
}

export class ApiSalesPersonClientResponseModel {
	bonus : number;
	businessEntityID : number;
	commissionPct : number;
	modifiedDate : any;
	rowguid : any;
	salesLastYear : number;
	salesQuota : any;
	salesYTD : number;
	territoryID : any;
	territoryIDEntity : string;

	constructor() {
		this.bonus = 0;
		this.businessEntityID = 0;
		this.commissionPct = 0;
		this.modifiedDate = null;
		this.rowguid = null;
		this.salesLastYear = 0;
		this.salesQuota = null;
		this.salesYTD = 0;
		this.territoryID = null;
		this.territoryIDEntity = '';
	}
}
export class ApiSalesReasonClientRequestModel {
	modifiedDate : any;
	name : string;
	reasonType : string;
	salesReasonID : number;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.reasonType = '';
		this.salesReasonID = 0;
	}
}

export class ApiSalesReasonClientResponseModel {
	modifiedDate : any;
	name : string;
	reasonType : string;
	salesReasonID : number;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.reasonType = '';
		this.salesReasonID = 0;
	}
}
export class ApiSalesTaxRateClientRequestModel {
	modifiedDate : any;
	name : string;
	rowguid : any;
	salesTaxRateID : number;
	stateProvinceID : number;
	taxRate : number;
	taxType : number;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.rowguid = null;
		this.salesTaxRateID = 0;
		this.stateProvinceID = 0;
		this.taxRate = 0;
		this.taxType = 0;
	}
}

export class ApiSalesTaxRateClientResponseModel {
	modifiedDate : any;
	name : string;
	rowguid : any;
	salesTaxRateID : number;
	stateProvinceID : number;
	taxRate : number;
	taxType : number;

	constructor() {
		this.modifiedDate = null;
		this.name = '';
		this.rowguid = null;
		this.salesTaxRateID = 0;
		this.stateProvinceID = 0;
		this.taxRate = 0;
		this.taxType = 0;
	}
}
export class ApiSalesTerritoryClientRequestModel {
	costLastYear : number;
	costYTD : number;
	countryRegionCode : string;
	group : string;
	modifiedDate : any;
	name : string;
	rowguid : any;
	salesLastYear : number;
	salesYTD : number;
	territoryID : number;

	constructor() {
		this.costLastYear = 0;
		this.costYTD = 0;
		this.countryRegionCode = '';
		this.group = '';
		this.modifiedDate = null;
		this.name = '';
		this.rowguid = null;
		this.salesLastYear = 0;
		this.salesYTD = 0;
		this.territoryID = 0;
	}
}

export class ApiSalesTerritoryClientResponseModel {
	costLastYear : number;
	costYTD : number;
	countryRegionCode : string;
	group : string;
	modifiedDate : any;
	name : string;
	rowguid : any;
	salesLastYear : number;
	salesYTD : number;
	territoryID : number;

	constructor() {
		this.costLastYear = 0;
		this.costYTD = 0;
		this.countryRegionCode = '';
		this.group = '';
		this.modifiedDate = null;
		this.name = '';
		this.rowguid = null;
		this.salesLastYear = 0;
		this.salesYTD = 0;
		this.territoryID = 0;
	}
}
export class ApiShoppingCartItemClientRequestModel {
	dateCreated : any;
	modifiedDate : any;
	productID : number;
	quantity : number;
	shoppingCartID : string;
	shoppingCartItemID : number;

	constructor() {
		this.dateCreated = null;
		this.modifiedDate = null;
		this.productID = 0;
		this.quantity = 0;
		this.shoppingCartID = '';
		this.shoppingCartItemID = 0;
	}
}

export class ApiShoppingCartItemClientResponseModel {
	dateCreated : any;
	modifiedDate : any;
	productID : number;
	quantity : number;
	shoppingCartID : string;
	shoppingCartItemID : number;

	constructor() {
		this.dateCreated = null;
		this.modifiedDate = null;
		this.productID = 0;
		this.quantity = 0;
		this.shoppingCartID = '';
		this.shoppingCartItemID = 0;
	}
}
export class ApiSpecialOfferClientRequestModel {
	category : string;
	description : string;
	discountPct : number;
	endDate : any;
	maxQty : any;
	minQty : number;
	modifiedDate : any;
	rowguid : any;
	specialOfferID : number;
	startDate : any;
	type : string;

	constructor() {
		this.category = '';
		this.description = '';
		this.discountPct = 0;
		this.endDate = null;
		this.maxQty = null;
		this.minQty = 0;
		this.modifiedDate = null;
		this.rowguid = null;
		this.specialOfferID = 0;
		this.startDate = null;
		this.type = '';
	}
}

export class ApiSpecialOfferClientResponseModel {
	category : string;
	description : string;
	discountPct : number;
	endDate : any;
	maxQty : any;
	minQty : number;
	modifiedDate : any;
	rowguid : any;
	specialOfferID : number;
	startDate : any;
	type : string;

	constructor() {
		this.category = '';
		this.description = '';
		this.discountPct = 0;
		this.endDate = null;
		this.maxQty = null;
		this.minQty = 0;
		this.modifiedDate = null;
		this.rowguid = null;
		this.specialOfferID = 0;
		this.startDate = null;
		this.type = '';
	}
}
export class ApiStoreClientRequestModel {
	businessEntityID : number;
	demographic : string;
	modifiedDate : any;
	name : string;
	rowguid : any;
	salesPersonID : any;
	salesPersonIDEntity : string;

	constructor() {
		this.businessEntityID = 0;
		this.demographic = '';
		this.modifiedDate = null;
		this.name = '';
		this.rowguid = null;
		this.salesPersonID = null;
		this.salesPersonIDEntity = '';
	}
}

export class ApiStoreClientResponseModel {
	businessEntityID : number;
	demographic : string;
	modifiedDate : any;
	name : string;
	rowguid : any;
	salesPersonID : any;
	salesPersonIDEntity : string;

	constructor() {
		this.businessEntityID = 0;
		this.demographic = '';
		this.modifiedDate = null;
		this.name = '';
		this.rowguid = null;
		this.salesPersonID = null;
		this.salesPersonIDEntity = '';
	}
}

/*<Codenesium>
    <Hash>bff5fd03d847d2f45b5b41d9280263fd</Hash>
</Codenesium>*/