import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import SpecialOfferMapper from './specialOfferMapper';
import SpecialOfferViewModel from './specialOfferViewModel';

interface Props {
    model?:SpecialOfferViewModel
}

   const SpecialOfferCreateDisplay: React.SFC<FormikProps<SpecialOfferViewModel>> = (props: FormikProps<SpecialOfferViewModel>) => {

   let status = props.status as CreateResponse<Api.SpecialOfferClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof SpecialOfferViewModel]  && props.errors[name as keyof SpecialOfferViewModel]) {
            response += props.errors[name as keyof SpecialOfferViewModel];
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
                        <label htmlFor="name" className={errorExistForField("category") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Category</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="category" className={errorExistForField("category") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("category") && <small className="text-danger">{errorsForField("category")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("description") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Description</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="description" className={errorExistForField("description") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("description") && <small className="text-danger">{errorsForField("description")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("discountPct") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DiscountPct</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="discountPct" className={errorExistForField("discountPct") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("discountPct") && <small className="text-danger">{errorsForField("discountPct")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("endDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>EndDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="endDate" className={errorExistForField("endDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("endDate") && <small className="text-danger">{errorsForField("endDate")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("maxQty") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>MaxQty</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="maxQty" className={errorExistForField("maxQty") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("maxQty") && <small className="text-danger">{errorsForField("maxQty")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("minQty") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>MinQty</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="minQty" className={errorExistForField("minQty") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("minQty") && <small className="text-danger">{errorsForField("minQty")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("rowguid") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Rowguid</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="rowguid" className={errorExistForField("rowguid") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("rowguid") && <small className="text-danger">{errorsForField("rowguid")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("startDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>StartDate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="startDate" className={errorExistForField("startDate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("startDate") && <small className="text-danger">{errorsForField("startDate")}</small>}
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


const SpecialOfferCreate = withFormik<Props, SpecialOfferViewModel>({
    mapPropsToValues: props => {
                
		let response = new SpecialOfferViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.category,props.model!.description,props.model!.discountPct,props.model!.endDate,props.model!.maxQty,props.model!.minQty,props.model!.modifiedDate,props.model!.rowguid,props.model!.specialOfferID,props.model!.startDate);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<SpecialOfferViewModel> = { };

	  if(values.category == '') {
                errors.category = "Required"
                    }if(values.description == '') {
                errors.description = "Required"
                    }if(values.discountPct == 0) {
                errors.discountPct = "Required"
                    }if(values.endDate == undefined) {
                errors.endDate = "Required"
                    }if(values.minQty == 0) {
                errors.minQty = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.rowguid == undefined) {
                errors.rowguid = "Required"
                    }if(values.startDate == undefined) {
                errors.startDate = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new SpecialOfferMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.SpecialOffers,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.SpecialOfferClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'SpecialOfferCreate', 
  })(SpecialOfferCreateDisplay);

  interface SpecialOfferCreateComponentProps
  {
  }

  interface SpecialOfferCreateComponentState
  {
      model?:SpecialOfferViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class SpecialOfferCreateComponent extends React.Component<SpecialOfferCreateComponentProps, SpecialOfferCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<SpecialOfferCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>ac91789ebf04d522a3c0d0c79de3a7f6</Hash>
</Codenesium>*/