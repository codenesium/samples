import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import DepartmentViewModel from './departmentViewModel';
import DepartmentMapper from './departmentMapper';

interface Props {
    model?:DepartmentViewModel
}

  const DepartmentEditDisplay = (props: FormikProps<DepartmentViewModel>) => {

   let status = props.status as UpdateResponse<Api.DepartmentClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof DepartmentViewModel]  && props.errors[name as keyof DepartmentViewModel]) {
            response += props.errors[name as keyof DepartmentViewModel];
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
                        <label htmlFor="name" className={errorExistForField("departmentID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DepartmentID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="departmentID" className={errorExistForField("departmentID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("departmentID") && <small className="text-danger">{errorsForField("departmentID")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("groupName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>GroupName</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="groupName" className={errorExistForField("groupName") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("groupName") && <small className="text-danger">{errorsForField("groupName")}</small>}
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


const DepartmentEdit = withFormik<Props, DepartmentViewModel>({
    mapPropsToValues: props => {
        let response = new DepartmentViewModel();
		response.setProperties(props.model!.departmentID,props.model!.groupName,props.model!.modifiedDate,props.model!.name);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<DepartmentViewModel> = { };

	  if(values.departmentID == 0) {
                errors.departmentID = "Required"
                    }if(values.groupName == '') {
                errors.groupName = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new DepartmentMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Departments +'/' + values.departmentID,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.DepartmentClientRequestModel>;
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
  
    displayName: 'DepartmentEdit', 
  })(DepartmentEditDisplay);

 
  interface IParams 
  {
     departmentID:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface DepartmentEditComponentProps
  {
     match:IMatch;
  }

  interface DepartmentEditComponentState
  {
      model?:DepartmentViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class DepartmentEditComponent extends React.Component<DepartmentEditComponentProps, DepartmentEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Departments + '/' + this.props.match.params.departmentID, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.DepartmentClientResponseModel;
            
            console.log(response);

			let mapper = new DepartmentMapper();

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
            return (<DepartmentEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>679728a48beda64e1a3b390700dd21fa</Hash>
</Codenesium>*/