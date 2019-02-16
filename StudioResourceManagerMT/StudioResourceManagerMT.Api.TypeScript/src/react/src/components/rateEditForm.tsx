import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import {UpdateResponse} from '../api/ApiObjects'
import Constants from '../constants'
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import RateViewModel from '../viewmodels/rateViewModel';
import RateMapper from '../mapping/rateMapper';

interface Props {
    model?:RateViewModel
}

  const RateEditDisplay = (props: FormikProps<RateViewModel>) => {

   let status = props.status as UpdateResponse<Api.RateClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof RateViewModel]  && props.errors[name as keyof RateViewModel]) {
            response += props.errors[name as keyof RateViewModel];
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
                      <label htmlFor="name" className={errorExistForField("amountPerMinute") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>AmountPerMinute</label>
					<div className="col-sm-12">
                         <Field type="input" name="amountPerMinute" className ={errorExistForField("amountPerMinute") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("amountPerMinute") && <small className="text-danger">{errorsForField("amountPerMinute")}</small>}

                    </div>
                </div>
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
                      <label htmlFor="name" className={errorExistForField("teacherId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TeacherId</label>
					<div className="col-sm-12">
                         <Field type="input" name="teacherId" className ={errorExistForField("teacherId") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("teacherId") && <small className="text-danger">{errorsForField("teacherId")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("teacherSkillId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TeacherSkillId</label>
					<div className="col-sm-12">
                         <Field type="input" name="teacherSkillId" className ={errorExistForField("teacherSkillId") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("teacherSkillId") && <small className="text-danger">{errorsForField("teacherSkillId")}</small>}

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


const RateUpdate = withFormik<Props, RateViewModel>({
    mapPropsToValues: props => {
        let response = new RateViewModel();
		response.setProperties(props.model!.amountPerMinute,props.model!.id,props.model!.isDeleted,props.model!.teacherId,props.model!.teacherSkillId,props.model!.tenantId);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<RateViewModel> = { };

	  if(values.amountPerMinute == 0) {
                errors.amountPerMinute = "Required"
                    }if(values.id == 0) {
                errors.id = "Required"
                    }if(values.isDeleted == false) {
                errors.isDeleted = "Required"
                    }if(values.teacherId == 0) {
                errors.teacherId = "Required"
                    }if(values.teacherSkillId == 0) {
                errors.teacherSkillId = "Required"
                    }if(values.tenantId == 0) {
                errors.tenantId = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new RateMapper();

        axios.put(Constants.ApiUrl + 'rates/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.RateClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
            let response = error.response.data as UpdateResponse<Api.RateClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        })
        .then(response =>
        {
            // cleanup
        })
    },
  
    displayName: 'RateEdit', 
  })(RateEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface RateEditComponentProps
  {
     match:IMatch;
  }

  interface RateEditComponentState
  {
      model?:RateViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class RateEditComponent extends React.Component<RateEditComponentProps, RateEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiUrl + 'rates/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.RateClientResponseModel;
            
            console.log(response);

			let mapper = new RateMapper();

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            let response = error.response.data as UpdateResponse<Api.RateClientRequestModel>;
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
            console.log(response);
        })
    }
    render () {

        if (this.state.loading) {
            return (<div>loading</div>);
        } 
        else if (this.state.loaded) {
            return (<RateUpdate model={this.state.model} />);
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
    <Hash>b11a1bd12031abb186c54277afd6104c</Hash>
</Codenesium>*/