import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import MessengerMapper from './messengerMapper';
import MessengerViewModel from './messengerViewModel';

interface Props {
    model?:MessengerViewModel
}

   const MessengerCreateDisplay: React.SFC<FormikProps<MessengerViewModel>> = (props: FormikProps<MessengerViewModel>) => {

   let status = props.status as CreateResponse<Api.MessengerClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof MessengerViewModel]  && props.errors[name as keyof MessengerViewModel]) {
            response += props.errors[name as keyof MessengerViewModel];
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
                        <label htmlFor="name" className={errorExistForField("date") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Date</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="date" className={errorExistForField("date") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("date") && <small className="text-danger">{errorsForField("date")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fromUserId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>From_user_id</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fromUserId" className={errorExistForField("fromUserId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fromUserId") && <small className="text-danger">{errorsForField("fromUserId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("messageId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Message_id</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="messageId" className={errorExistForField("messageId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("messageId") && <small className="text-danger">{errorsForField("messageId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("time") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Time</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="time" className={errorExistForField("time") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("time") && <small className="text-danger">{errorsForField("time")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("toUserId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>To_user_id</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="toUserId" className={errorExistForField("toUserId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("toUserId") && <small className="text-danger">{errorsForField("toUserId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("userId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>User_id</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="userId" className={errorExistForField("userId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("userId") && <small className="text-danger">{errorsForField("userId")}</small>}
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


const MessengerCreate = withFormik<Props, MessengerViewModel>({
    mapPropsToValues: props => {
                
		let response = new MessengerViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.date,props.model!.fromUserId,props.model!.id,props.model!.messageId,props.model!.time,props.model!.toUserId,props.model!.userId);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<MessengerViewModel> = { };

	  if(values.toUserId == 0) {
                errors.toUserId = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new MessengerMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Messengers,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.MessengerClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'MessengerCreate', 
  })(MessengerCreateDisplay);

  interface MessengerCreateComponentProps
  {
  }

  interface MessengerCreateComponentState
  {
      model?:MessengerViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class MessengerCreateComponent extends React.Component<MessengerCreateComponentProps, MessengerCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<MessengerCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>aac7722c61f173050976ebb0d8d802f7</Hash>
</Codenesium>*/