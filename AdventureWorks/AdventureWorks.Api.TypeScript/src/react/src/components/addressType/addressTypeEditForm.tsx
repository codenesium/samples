import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import AddressTypeViewModel from './addressTypeViewModel';
import AddressTypeMapper from './addressTypeMapper';

interface Props {
    model?:AddressTypeViewModel
}

  const AddressTypeEditDisplay = (props: FormikProps<AddressTypeViewModel>) => {

   let status = props.status as UpdateResponse<Api.AddressTypeClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof AddressTypeViewModel]  && props.errors[name as keyof AddressTypeViewModel]) {
            response += props.errors[name as keyof AddressTypeViewModel];
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
                        <label htmlFor="name" className={errorExistForField("addressTypeID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>AddressTypeID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="addressTypeID" className={errorExistForField("addressTypeID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("addressTypeID") && <small className="text-danger">{errorsForField("addressTypeID")}</small>}
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


const AddressTypeEdit = withFormik<Props, AddressTypeViewModel>({
    mapPropsToValues: props => {
        let response = new AddressTypeViewModel();
		response.setProperties(props.model!.addressTypeID,props.model!.modifiedDate,props.model!.name,props.model!.rowguid);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<AddressTypeViewModel> = { };

	  if(values.addressTypeID == 0) {
                errors.addressTypeID = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }if(values.rowguid == undefined) {
                errors.rowguid = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new AddressTypeMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.AddressTypes +'/' + values.addressTypeID,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.AddressTypeClientRequestModel>;
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
  
    displayName: 'AddressTypeEdit', 
  })(AddressTypeEditDisplay);

 
  interface IParams 
  {
     addressTypeID:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface AddressTypeEditComponentProps
  {
     match:IMatch;
  }

  interface AddressTypeEditComponentState
  {
      model?:AddressTypeViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class AddressTypeEditComponent extends React.Component<AddressTypeEditComponentProps, AddressTypeEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.AddressTypes + '/' + this.props.match.params.addressTypeID, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.AddressTypeClientResponseModel;
            
            console.log(response);

			let mapper = new AddressTypeMapper();

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
            return (<AddressTypeEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>260409100197c04942e711d227a6b8c8</Hash>
</Codenesium>*/