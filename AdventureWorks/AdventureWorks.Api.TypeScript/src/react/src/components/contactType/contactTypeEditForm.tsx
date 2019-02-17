import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ContactTypeViewModel from './contactTypeViewModel';
import ContactTypeMapper from './contactTypeMapper';

interface Props {
    model?:ContactTypeViewModel
}

  const ContactTypeEditDisplay = (props: FormikProps<ContactTypeViewModel>) => {

   let status = props.status as UpdateResponse<Api.ContactTypeClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof ContactTypeViewModel]  && props.errors[name as keyof ContactTypeViewModel]) {
            response += props.errors[name as keyof ContactTypeViewModel];
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
                        <label htmlFor="name" className={errorExistForField("contactTypeID") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ContactTypeID</label>
					    <div className="col-sm-12">
                             <Field type="datetime-local" name="contactTypeID" className={errorExistForField("contactTypeID") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("contactTypeID") && <small className="text-danger">{errorsForField("contactTypeID")}</small>}
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


const ContactTypeEdit = withFormik<Props, ContactTypeViewModel>({
    mapPropsToValues: props => {
        let response = new ContactTypeViewModel();
		response.setProperties(props.model!.contactTypeID,props.model!.modifiedDate,props.model!.name);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<ContactTypeViewModel> = { };

	  if(values.contactTypeID == 0) {
                errors.contactTypeID = "Required"
                    }if(values.modifiedDate == undefined) {
                errors.modifiedDate = "Required"
                    }if(values.name == '') {
                errors.name = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new ContactTypeMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.ContactTypes +'/' + values.contactTypeID,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.ContactTypeClientRequestModel>;
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
  
    displayName: 'ContactTypeEdit', 
  })(ContactTypeEditDisplay);

 
  interface IParams 
  {
     contactTypeID:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface ContactTypeEditComponentProps
  {
     match:IMatch;
  }

  interface ContactTypeEditComponentState
  {
      model?:ContactTypeViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class ContactTypeEditComponent extends React.Component<ContactTypeEditComponentProps, ContactTypeEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.ContactTypes + '/' + this.props.match.params.contactTypeID, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.ContactTypeClientResponseModel;
            
            console.log(response);

			let mapper = new ContactTypeMapper();

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
            return (<ContactTypeEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>73b2b682ed85d3988d2785777a0f9da6</Hash>
</Codenesium>*/