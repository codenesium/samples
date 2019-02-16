import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import {UpdateResponse} from '../api/ApiObjects'
import Constants from '../constants'
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import FamilyViewModel from '../viewmodels/familyViewModel';
import FamilyMapper from '../mapping/familyMapper';

interface Props {
    model?:FamilyViewModel
}

  const FamilyEditDisplay = (props: FormikProps<FamilyViewModel>) => {

   let status = props.status as UpdateResponse<Api.FamilyClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof FamilyViewModel]  && props.errors[name as keyof FamilyViewModel]) {
            response += props.errors[name as keyof FamilyViewModel];
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

   return (

          <form onSubmit={props.handleSubmit} role="form">
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("id") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Id</label>
					<div className="col-sm-12">
                         <Field type="input" name="id" className ={errorExistForField("id") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("id") && <small className="text-danger">{errorsForField("id")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("isDeleted") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>IsDeleted</label>
					<div className="col-sm-12">
                         <Field type="input" name="isDeleted" className ={errorExistForField("isDeleted") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("isDeleted") && <small className="text-danger">{errorsForField("isDeleted")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("note") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Note</label>
					<div className="col-sm-12">
                         <Field type="input" name="note" className ={errorExistForField("note") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("note") && <small className="text-danger">{errorsForField("note")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("primaryContactEmail") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PrimaryContactEmail</label>
					<div className="col-sm-12">
                         <Field type="input" name="primaryContactEmail" className ={errorExistForField("primaryContactEmail") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("primaryContactEmail") && <small className="text-danger">{errorsForField("primaryContactEmail")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("primaryContactFirstName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PrimaryContactFirstName</label>
					<div className="col-sm-12">
                         <Field type="input" name="primaryContactFirstName" className ={errorExistForField("primaryContactFirstName") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("primaryContactFirstName") && <small className="text-danger">{errorsForField("primaryContactFirstName")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("primaryContactLastName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PrimaryContactLastName</label>
					<div className="col-sm-12">
                         <Field type="input" name="primaryContactLastName" className ={errorExistForField("primaryContactLastName") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("primaryContactLastName") && <small className="text-danger">{errorsForField("primaryContactLastName")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("primaryContactPhone") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PrimaryContactPhone</label>
					<div className="col-sm-12">
                         <Field type="input" name="primaryContactPhone" className ={errorExistForField("primaryContactPhone") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("primaryContactPhone") && <small className="text-danger">{errorsForField("primaryContactPhone")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("tenantId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TenantId</label>
					<div className="col-sm-12">
                         <Field type="input" name="tenantId" className ={errorExistForField("tenantId") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("tenantId") && <small className="text-danger">{errorsForField("tenantId")}</small>}

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
          </form>
  );
}


const FamilyUpdate = withFormik<Props, FamilyViewModel>({
    mapPropsToValues: props => {
        let response = new FamilyViewModel();
		response.setProperties(props.model!.id,props.model!.isDeleted,props.model!.note,props.model!.primaryContactEmail,props.model!.primaryContactFirstName,props.model!.primaryContactLastName,props.model!.primaryContactPhone,props.model!.tenantId);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<FamilyViewModel> = { };

	  if(values.id == 0) {
                errors.id = "Required"
                    }if(values.isDeleted == false) {
                errors.isDeleted = "Required"
                    }if(values.primaryContactPhone == '') {
                errors.primaryContactPhone = "Required"
                    }if(values.tenantId == 0) {
                errors.tenantId = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new FamilyMapper();

        axios.put(Constants.ApiUrl + 'families/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.FamilyClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
            let response = error.response.data as UpdateResponse<Api.FamilyClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        })
        .then(response =>
        {
            // cleanup
        })
    },
  
    displayName: 'FamilyEdit', 
  })(FamilyEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface FamilyEditComponentProps
  {
     match:IMatch;
  }

  interface FamilyEditComponentState
  {
      model?:FamilyViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class FamilyEditComponent extends React.Component<FamilyEditComponentProps, FamilyEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiUrl + 'families/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.FamilyClientResponseModel;
            
            console.log(response);

			let mapper = new FamilyMapper();

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            let response = error.response.data as UpdateResponse<Api.FamilyClientRequestModel>;
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
            console.log(response);
        })
    }
    render () {

        if (this.state.loading) {
            return (<div>loading</div>);
        } 
        else if (this.state.loaded) {
            return (<FamilyUpdate model={this.state.model} />);
        } 
        else if (this.state.errorOccurred) {
            return (<div>{this.state.errorMessage}</div>);
        }
        else {
            return (<div></div>);   
        }
    }
}

/*<Codenesium>
    <Hash>4bdee56a595032da67356cd1b896e10f</Hash>
</Codenesium>*/