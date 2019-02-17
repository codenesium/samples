import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ShipMethodViewModel from './shipMethodViewModel';
import ShipMethodMapper from './shipMethodMapper';

interface Props {
    model?:ShipMethodViewModel
}

  const ShipMethodEditDisplay = (props: FormikProps<ShipMethodViewModel>) => {

   let status = props.status as UpdateResponse<Api.ShipMethodClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof ShipMethodViewModel]  && props.errors[name as keyof ShipMethodViewModel]) {
            response += props.errors[name as keyof ShipMethodViewModel];
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
                        <label htmlFor="name" className={errorExistForField("shipBase") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ShipBase</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="shipBase" className={errorExistForField("shipBase") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("shipBase") && <small className="text-danger">{errorsForField("shipBase")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("shipMethodID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ShipMethodID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="shipMethodID" className={errorExistForField("shipMethodID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("shipMethodID") && <small className="text-danger">{errorsForField("shipMethodID")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("shipRate") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ShipRate</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="shipRate" className={errorExistForField("shipRate") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("shipRate") && <small className="text-danger">{errorsForField("shipRate")}</small>}
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


const ShipMethodEdit = withFormik<Props, ShipMethodViewModel>({
    mapPropsToValues: props => {
        let response = new ShipMethodViewModel();
		response.setProperties(props.model!.modifiedDate,props.model!.name,props.model!.rowguid,props.model!.shipBase,props.model!.shipMethodID,props.model!.shipRate);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<ShipMethodViewModel> = { };

	  if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.rowguid == undefined) {
                errors.rowguid = "Required"
                    }if(values.shipBase == 0) {
                errors.shipBase = "Required"
                    }if(values.shipMethodID == 0) {
                errors.shipMethodID = "Required"
                    }if(values.shipRate == 0) {
                errors.shipRate = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new ShipMethodMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.ShipMethods +'/' + values.shipMethodID,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.ShipMethodClientRequestModel>;
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
  
    displayName: 'ShipMethodEdit', 
  })(ShipMethodEditDisplay);

 
  interface IParams 
  {
     shipMethodID:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface ShipMethodEditComponentProps
  {
     match:IMatch;
  }

  interface ShipMethodEditComponentState
  {
      model?:ShipMethodViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class ShipMethodEditComponent extends React.Component<ShipMethodEditComponentProps, ShipMethodEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.ShipMethods + '/' + this.props.match.params.shipMethodID, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.ShipMethodClientResponseModel;
            
            console.log(response);

			let mapper = new ShipMethodMapper();

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
            return (<ShipMethodEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>a52ab4473a4527d2e2af7dbbde438ecd</Hash>
</Codenesium>*/