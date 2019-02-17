import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ProductMapper from './productMapper';
import ProductViewModel from './productViewModel';

interface Props {
    model?:ProductViewModel
}

   const ProductCreateDisplay: React.SFC<FormikProps<ProductViewModel>> = (props: FormikProps<ProductViewModel>) => {

   let status = props.status as CreateResponse<Api.ProductClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof ProductViewModel]  && props.errors[name as keyof ProductViewModel]) {
            response += props.errors[name as keyof ProductViewModel];
        }

        if(status && status.validationErrors && status.validationErrors.find(f => f.propertyName.toLowerCase() == name.toLowerCase())) {
            response += status.validationErrors.filter(f => f.propertyName.toLowerCase() == name.toLowerCase())[0].errorMessage;
        }

        return response;
   }

   let errorExistForField = (name:string) : boolean =>
   {
        return errorsForField(name) != '';
   }

   return (<form onSubmit={props.handleSubmit} role="form">            
            			<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("color") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Color</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="color" className={errorExistForField("color") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("color") && <small className="text-danger">{errorsForField("color")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("daysToManufacture") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DaysToManufacture</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="daysToManufacture" className={errorExistForField("daysToManufacture") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("daysToManufacture") && <small className="text-danger">{errorsForField("daysToManufacture")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("discontinuedDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DiscontinuedDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="discontinuedDate" className={errorExistForField("discontinuedDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("discontinuedDate") && <small className="text-danger">{errorsForField("discontinuedDate")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("finishedGoodsFlag") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FinishedGoodsFlag</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="finishedGoodsFlag" className={errorExistForField("finishedGoodsFlag") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("finishedGoodsFlag") && <small className="text-danger">{errorsForField("finishedGoodsFlag")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("listPrice") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ListPrice</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="listPrice" className={errorExistForField("listPrice") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("listPrice") && <small className="text-danger">{errorsForField("listPrice")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("makeFlag") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>MakeFlag</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="makeFlag" className={errorExistForField("makeFlag") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("makeFlag") && <small className="text-danger">{errorsForField("makeFlag")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("modifiedDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ModifiedDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="modifiedDate" className={errorExistForField("modifiedDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("modifiedDate") && <small className="text-danger">{errorsForField("modifiedDate")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("name") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Name</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="name" className={errorExistForField("name") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("name") && <small className="text-danger">{errorsForField("name")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("productLine") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ProductLine</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="productLine" className={errorExistForField("productLine") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("productLine") && <small className="text-danger">{errorsForField("productLine")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("productModelID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ProductModelID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="productModelID" className={errorExistForField("productModelID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("productModelID") && <small className="text-danger">{errorsForField("productModelID")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("productNumber") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ProductNumber</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="productNumber" className={errorExistForField("productNumber") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("productNumber") && <small className="text-danger">{errorsForField("productNumber")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("productSubcategoryID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ProductSubcategoryID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="productSubcategoryID" className={errorExistForField("productSubcategoryID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("productSubcategoryID") && <small className="text-danger">{errorsForField("productSubcategoryID")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("reorderPoint") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ReorderPoint</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="reorderPoint" className={errorExistForField("reorderPoint") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("reorderPoint") && <small className="text-danger">{errorsForField("reorderPoint")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("rowguid") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Rowguid</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="rowguid" className={errorExistForField("rowguid") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("rowguid") && <small className="text-danger">{errorsForField("rowguid")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("safetyStockLevel") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>SafetyStockLevel</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="safetyStockLevel" className={errorExistForField("safetyStockLevel") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("safetyStockLevel") && <small className="text-danger">{errorsForField("safetyStockLevel")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("sellEndDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>SellEndDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="sellEndDate" className={errorExistForField("sellEndDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("sellEndDate") && <small className="text-danger">{errorsForField("sellEndDate")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("sellStartDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>SellStartDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="sellStartDate" className={errorExistForField("sellStartDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("sellStartDate") && <small className="text-danger">{errorsForField("sellStartDate")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("size") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Size</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="size" className={errorExistForField("size") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("size") && <small className="text-danger">{errorsForField("size")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("sizeUnitMeasureCode") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>SizeUnitMeasureCode</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="sizeUnitMeasureCode" className={errorExistForField("sizeUnitMeasureCode") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("sizeUnitMeasureCode") && <small className="text-danger">{errorsForField("sizeUnitMeasureCode")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("standardCost") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>StandardCost</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="standardCost" className={errorExistForField("standardCost") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("standardCost") && <small className="text-danger">{errorsForField("standardCost")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("style") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Style</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="style" className={errorExistForField("style") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("style") && <small className="text-danger">{errorsForField("style")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("weight") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Weight</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="weight" className={errorExistForField("weight") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("weight") && <small className="text-danger">{errorsForField("weight")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("weightUnitMeasureCode") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>WeightUnitMeasureCode</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="weightUnitMeasureCode" className={errorExistForField("weightUnitMeasureCode") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("weightUnitMeasureCode") && <small className="text-danger">{errorsForField("weightUnitMeasureCode")}</small>}
                        </div>
                    </div>

			
            <button type="submit" className="btn btn-primary" disabled={false}>
                Submit
            </button>
            <br />
            <br />
            { 
                status && status.success ? (<div className="alert alert-success">Success</div>): (null)
            }
                        
            { 
                status && !status.success ? (<div className="alert alert-danger">Error occurred</div>): (null)
            }
          </form>);
}


const ProductCreate = withFormik<Props, ProductViewModel>({
    mapPropsToValues: props => {
                
		let response = new ProductViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.color,props.model!.daysToManufacture,props.model!.discontinuedDate,props.model!.finishedGoodsFlag,props.model!.listPrice,props.model!.makeFlag,props.model!.modifiedDate,props.model!.name,props.model!.productID,props.model!.productLine,props.model!.productModelID,props.model!.productNumber,props.model!.productSubcategoryID,props.model!.reorderPoint,props.model!.rowguid,props.model!.safetyStockLevel,props.model!.sellEndDate,props.model!.sellStartDate,props.model!.size,props.model!.sizeUnitMeasureCode,props.model!.standardCost,props.model!.style,props.model!.weight,props.model!.weightUnitMeasureCode);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<ProductViewModel> = { };

	  if(values.daysToManufacture == 0) {
                errors.daysToManufacture = "Required"
                    }if(values.listPrice == 0) {
                errors.listPrice = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.productNumber == '') {
                errors.productNumber = "Required"
                    }if(values.reorderPoint == 0) {
                errors.reorderPoint = "Required"
                    }if(values.rowguid == undefined) {
                errors.rowguid = "Required"
                    }if(values.safetyStockLevel == 0) {
                errors.safetyStockLevel = "Required"
                    }if(values.sellStartDate == undefined) {
                errors.sellStartDate = "Required"
                    }if(values.standardCost == 0) {
                errors.standardCost = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new ProductMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Products,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.ProductClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'ProductCreate', 
  })(ProductCreateDisplay);

  interface ProductCreateComponentProps
  {
  }

  interface ProductCreateComponentState
  {
      model?:ProductViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class ProductCreateComponent extends React.Component<ProductCreateComponentProps, ProductCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<ProductCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>41911646e015f37a047d31c7cfafa21d</Hash>
</Codenesium>*/