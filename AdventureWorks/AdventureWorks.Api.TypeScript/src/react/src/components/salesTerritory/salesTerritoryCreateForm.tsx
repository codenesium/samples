import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import SalesTerritoryMapper from './salesTerritoryMapper';
import SalesTerritoryViewModel from './salesTerritoryViewModel';

interface Props {
    model?:SalesTerritoryViewModel
}

   const SalesTerritoryCreateDisplay: React.SFC<FormikProps<SalesTerritoryViewModel>> = (props: FormikProps<SalesTerritoryViewModel>) => {

   let status = props.status as CreateResponse<Api.SalesTerritoryClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof SalesTerritoryViewModel]  && props.errors[name as keyof SalesTerritoryViewModel]) {
            response += props.errors[name as keyof SalesTerritoryViewModel];
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
                        <label htmlFor="name" className={errorExistForField("costLastYear") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CostLastYear</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="costLastYear" className={errorExistForField("costLastYear") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("costLastYear") && <small className="text-danger">{errorsForField("costLastYear")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("costYTD") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CostYTD</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="costYTD" className={errorExistForField("costYTD") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("costYTD") && <small className="text-danger">{errorsForField("costYTD")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("countryRegionCode") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>CountryRegionCode</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="countryRegionCode" className={errorExistForField("countryRegionCode") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("countryRegionCode") && <small className="text-danger">{errorsForField("countryRegionCode")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("rowguid") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Rowguid</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="rowguid" className={errorExistForField("rowguid") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("rowguid") && <small className="text-danger">{errorsForField("rowguid")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("salesLastYear") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>SalesLastYear</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="salesLastYear" className={errorExistForField("salesLastYear") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("salesLastYear") && <small className="text-danger">{errorsForField("salesLastYear")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("salesYTD") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>SalesYTD</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="salesYTD" className={errorExistForField("salesYTD") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("salesYTD") && <small className="text-danger">{errorsForField("salesYTD")}</small>}
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


const SalesTerritoryCreate = withFormik<Props, SalesTerritoryViewModel>({
    mapPropsToValues: props => {
                
		let response = new SalesTerritoryViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.costLastYear,props.model!.costYTD,props.model!.countryRegionCode,props.model!.modifiedDate,props.model!.name,props.model!.rowguid,props.model!.salesLastYear,props.model!.salesYTD,props.model!.territoryID);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<SalesTerritoryViewModel> = { };

	  if(values.costLastYear == 0) {
                errors.costLastYear = "Required"
                    }if(values.costYTD == 0) {
                errors.costYTD = "Required"
                    }if(values.countryRegionCode == '') {
                errors.countryRegionCode = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.rowguid == undefined) {
                errors.rowguid = "Required"
                    }if(values.salesLastYear == 0) {
                errors.salesLastYear = "Required"
                    }if(values.salesYTD == 0) {
                errors.salesYTD = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new SalesTerritoryMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.SalesTerritories,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.SalesTerritoryClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'SalesTerritoryCreate', 
  })(SalesTerritoryCreateDisplay);

  interface SalesTerritoryCreateComponentProps
  {
  }

  interface SalesTerritoryCreateComponentState
  {
      model?:SalesTerritoryViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class SalesTerritoryCreateComponent extends React.Component<SalesTerritoryCreateComponentProps, SalesTerritoryCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<SalesTerritoryCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>de60db44a3a15a36dec3c6c8823dea79</Hash>
</Codenesium>*/