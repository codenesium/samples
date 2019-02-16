import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../api/models';
import {UpdateResponse} from '../api/ApiObjects'
import Constants from '../constants'
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import EventViewModel from '../viewmodels/eventViewModel';
import EventMapper from '../mapping/eventMapper';

interface Props {
    model?:EventViewModel
}

  const EventEditDisplay = (props: FormikProps<EventViewModel>) => {

   let status = props.status as UpdateResponse<Api.EventClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof EventViewModel]  && props.errors[name as keyof EventViewModel]) {
            response += props.errors[name as keyof EventViewModel];
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
                      <label htmlFor="name" className={errorExistForField("actualEndDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ActualEndDate</label>
					<div className="col-sm-12">
                         <Field type="input" name="actualEndDate" className ={errorExistForField("actualEndDate") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("actualEndDate") && <small className="text-danger">{errorsForField("actualEndDate")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("actualStartDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ActualStartDate</label>
					<div className="col-sm-12">
                         <Field type="input" name="actualStartDate" className ={errorExistForField("actualStartDate") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("actualStartDate") && <small className="text-danger">{errorsForField("actualStartDate")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("billAmount") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>BillAmount</label>
					<div className="col-sm-12">
                         <Field type="input" name="billAmount" className ={errorExistForField("billAmount") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("billAmount") && <small className="text-danger">{errorsForField("billAmount")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("eventStatusId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>EventStatusId</label>
					<div className="col-sm-12">
                         <Field type="input" name="eventStatusId" className ={errorExistForField("eventStatusId") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("eventStatusId") && <small className="text-danger">{errorsForField("eventStatusId")}</small>}

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
                      <label htmlFor="name" className={errorExistForField("scheduledEndDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ScheduledEndDate</label>
					<div className="col-sm-12">
                         <Field type="input" name="scheduledEndDate" className ={errorExistForField("scheduledEndDate") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("scheduledEndDate") && <small className="text-danger">{errorsForField("scheduledEndDate")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("scheduledStartDate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ScheduledStartDate</label>
					<div className="col-sm-12">
                         <Field type="input" name="scheduledStartDate" className ={errorExistForField("scheduledStartDate") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("scheduledStartDate") && <small className="text-danger">{errorsForField("scheduledStartDate")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("studentNote") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>StudentNote</label>
					<div className="col-sm-12">
                         <Field type="input" name="studentNote" className ={errorExistForField("studentNote") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("studentNote") && <small className="text-danger">{errorsForField("studentNote")}</small>}

                    </div>
                </div>
							<div className="form-group row">
                      <label htmlFor="name" className={errorExistForField("teacherNote") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TeacherNote</label>
					<div className="col-sm-12">
                         <Field type="input" name="teacherNote" className ={errorExistForField("teacherNote") ? "form-control is-invalid" : "form-control"} />

                        {errorExistForField("teacherNote") && <small className="text-danger">{errorsForField("teacherNote")}</small>}

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


const EventUpdate = withFormik<Props, EventViewModel>({
    mapPropsToValues: props => {
        let response = new EventViewModel();
		response.setProperties(props.model!.actualEndDate,props.model!.actualStartDate,props.model!.billAmount,props.model!.eventStatusId,props.model!.id,props.model!.isDeleted,props.model!.scheduledEndDate,props.model!.scheduledStartDate,props.model!.studentNote,props.model!.teacherNote,props.model!.tenantId);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<EventViewModel> = { };

	  if(values.eventStatusId == 0) {
                errors.eventStatusId = "Required"
                    }if(values.id == 0) {
                errors.id = "Required"
                    }if(values.isDeleted == false) {
                errors.isDeleted = "Required"
                    }if(values.tenantId == 0) {
                errors.tenantId = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new EventMapper();

        axios.put(Constants.ApiUrl + 'events/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.EventClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
            let response = error.response.data as UpdateResponse<Api.EventClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        })
        .then(response =>
        {
            // cleanup
        })
    },
  
    displayName: 'EventEdit', 
  })(EventEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface EventEditComponentProps
  {
     match:IMatch;
  }

  interface EventEditComponentState
  {
      model?:EventViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class EventEditComponent extends React.Component<EventEditComponentProps, EventEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiUrl + 'events/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.EventClientResponseModel;
            
            console.log(response);

			let mapper = new EventMapper();

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            let response = error.response.data as UpdateResponse<Api.EventClientRequestModel>;
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
            console.log(response);
        })
    }
    render () {

        if (this.state.loading) {
            return (<div>loading</div>);
        } 
        else if (this.state.loaded) {
            return (<EventUpdate model={this.state.model} />);
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
    <Hash>356355d1e3a7fb0cd00415e9617cf318</Hash>
</Codenesium>*/