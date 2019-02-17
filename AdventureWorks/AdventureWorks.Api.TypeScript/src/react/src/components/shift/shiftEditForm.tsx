import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ShiftViewModel from './shiftViewModel';
import ShiftMapper from './shiftMapper';

interface Props {
    model?:ShiftViewModel
}

  const ShiftEditDisplay = (props: FormikProps<ShiftViewModel>) => {

   let status = props.status as UpdateResponse<Api.ShiftClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof ShiftViewModel]  && props.errors[name as keyof ShiftViewModel]) {
            response += props.errors[name as keyof ShiftViewModel];
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
                        <label htmlFor="name" className={errorExistForField("endTime") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>EndTime</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="endTime" className={errorExistForField("endTime") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("endTime") && <small className="text-danger">{errorsForField("endTime")}</small>}
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
                        <label htmlFor="name" className={errorExistForField("shiftID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ShiftID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="shiftID" className={errorExistForField("shiftID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("shiftID") && <small className="text-danger">{errorsForField("shiftID")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("startTime") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>StartTime</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="startTime" className={errorExistForField("startTime") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("startTime") && <small className="text-danger">{errorsForField("startTime")}</small>}
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


const ShiftEdit = withFormik<Props, ShiftViewModel>({
    mapPropsToValues: props => {
        let response = new ShiftViewModel();
		response.setProperties(props.model!.endTime,props.model!.modifiedDate,props.model!.name,props.model!.shiftID,props.model!.startTime);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<ShiftViewModel> = { };

	  if(values.endTime == undefined) {
                errors.endTime = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.shiftID == 0) {
                errors.shiftID = "Required"
                    }if(values.startTime == undefined) {
                errors.startTime = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new ShiftMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Shifts +'/' + values.shiftID,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.ShiftClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
        }, 
		error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
        .then(response =>
        {
            // cleanup
        })
    },
  
    displayName: 'ShiftEdit', 
  })(ShiftEditDisplay);

 
  interface IParams 
  {
     shiftID:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface ShiftEditComponentProps
  {
     match:IMatch;
  }

  interface ShiftEditComponentState
  {
      model?:ShiftViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class ShiftEditComponent extends React.Component<ShiftEditComponentProps, ShiftEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Shifts + '/' + this.props.match.params.shiftID, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.ShiftClientResponseModel;
            
            console.log(response);

			let mapper = new ShiftMapper();

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, 
		error => {
            console.log(error);
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
        })
    }
    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
        else if (this.state.errorOccurred) {
			return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<ShiftEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>d09f1b09f2579938ab9db022eda938ff</Hash>
</Codenesium>*/