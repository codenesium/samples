import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import DatabaseLogViewModel from './databaseLogViewModel';
import DatabaseLogMapper from './databaseLogMapper';

interface Props {
    model?:DatabaseLogViewModel
}

  const DatabaseLogEditDisplay = (props: FormikProps<DatabaseLogViewModel>) => {

   let status = props.status as UpdateResponse<Api.DatabaseLogClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof DatabaseLogViewModel]  && props.errors[name as keyof DatabaseLogViewModel]) {
            response += props.errors[name as keyof DatabaseLogViewModel];
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
                        <label htmlFor="name" className={errorExistForField("databaseLogID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DatabaseLogID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="databaseLogID" className={errorExistForField("databaseLogID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("databaseLogID") && <small className="text-danger">{errorsForField("databaseLogID")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("databaseUser") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DatabaseUser</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="databaseUser" className={errorExistForField("databaseUser") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("databaseUser") && <small className="text-danger">{errorsForField("databaseUser")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("postTime") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PostTime</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="postTime" className={errorExistForField("postTime") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("postTime") && <small className="text-danger">{errorsForField("postTime")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("schema") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Schema</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="schema" className={errorExistForField("schema") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("schema") && <small className="text-danger">{errorsForField("schema")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("tsql") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TSQL</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="tsql" className={errorExistForField("tsql") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("tsql") && <small className="text-danger">{errorsForField("tsql")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("xmlEvent") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>XmlEvent</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="xmlEvent" className={errorExistForField("xmlEvent") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("xmlEvent") && <small className="text-danger">{errorsForField("xmlEvent")}</small>}
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


const DatabaseLogEdit = withFormik<Props, DatabaseLogViewModel>({
    mapPropsToValues: props => {
        let response = new DatabaseLogViewModel();
		response.setProperties(props.model!.databaseLogID,props.model!.databaseUser,props.model!.postTime,props.model!.schema,props.model!.tsql,props.model!.xmlEvent);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<DatabaseLogViewModel> = { };

	  if(values.databaseLogID == 0) {
                errors.databaseLogID = "Required"
                    }if(values.databaseUser == '') {
                errors.databaseUser = "Required"
                    }if(values.postTime == undefined) {
                errors.postTime = "Required"
                    }if(values.tsql == '') {
                errors.tsql = "Required"
                    }if(values.xmlEvent == '') {
                errors.xmlEvent = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new DatabaseLogMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.DatabaseLogs +'/' + values.databaseLogID,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.DatabaseLogClientRequestModel>;
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
  
    displayName: 'DatabaseLogEdit', 
  })(DatabaseLogEditDisplay);

 
  interface IParams 
  {
     databaseLogID:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface DatabaseLogEditComponentProps
  {
     match:IMatch;
  }

  interface DatabaseLogEditComponentState
  {
      model?:DatabaseLogViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class DatabaseLogEditComponent extends React.Component<DatabaseLogEditComponentProps, DatabaseLogEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.DatabaseLogs + '/' + this.props.match.params.databaseLogID, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.DatabaseLogClientResponseModel;
            
            console.log(response);

			let mapper = new DatabaseLogMapper();

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
            return (<DatabaseLogEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>fded6b85fbd89942b3685809108c223a</Hash>
</Codenesium>*/