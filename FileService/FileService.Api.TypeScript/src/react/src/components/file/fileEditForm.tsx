import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import FileViewModel from './fileViewModel';
import FileMapper from './fileMapper';

interface Props {
    model?:FileViewModel
}

  const FileEditDisplay = (props: FormikProps<FileViewModel>) => {

   let status = props.status as UpdateResponse<Api.FileClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   { 
        let response = '';
        if(props.touched[name as keyof FileViewModel]  && props.errors[name as keyof FileViewModel]) {
            response += props.errors[name as keyof FileViewModel];
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
                        <label htmlFor="name" className={errorExistForField("bucketId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>BucketId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="bucketId" className={errorExistForField("bucketId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("bucketId") && <small className="text-danger">{errorsForField("bucketId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("dateCreated") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>DateCreated</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="dateCreated" className={errorExistForField("dateCreated") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("dateCreated") && <small className="text-danger">{errorsForField("dateCreated")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("description") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Description</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="description" className={errorExistForField("description") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("description") && <small className="text-danger">{errorsForField("description")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("expiration") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Expiration</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="expiration" className={errorExistForField("expiration") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("expiration") && <small className="text-danger">{errorsForField("expiration")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("extension") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Extension</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="extension" className={errorExistForField("extension") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("extension") && <small className="text-danger">{errorsForField("extension")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("externalId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ExternalId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="externalId" className={errorExistForField("externalId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("externalId") && <small className="text-danger">{errorsForField("externalId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fileSizeInByte") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FileSizeInByte</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fileSizeInByte" className={errorExistForField("fileSizeInByte") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fileSizeInByte") && <small className="text-danger">{errorsForField("fileSizeInByte")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("fileTypeId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>FileTypeId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="fileTypeId" className={errorExistForField("fileTypeId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("fileTypeId") && <small className="text-danger">{errorsForField("fileTypeId")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("id") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Id</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="id" className={errorExistForField("id") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("id") && <small className="text-danger">{errorsForField("id")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("location") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Location</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="location" className={errorExistForField("location") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("location") && <small className="text-danger">{errorsForField("location")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("privateKey") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PrivateKey</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="privateKey" className={errorExistForField("privateKey") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("privateKey") && <small className="text-danger">{errorsForField("privateKey")}</small>}
                        </div>
                    </div>
							<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("publicKey") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>PublicKey</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="publicKey" className={errorExistForField("publicKey") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("publicKey") && <small className="text-danger">{errorsForField("publicKey")}</small>}
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


const FileEdit = withFormik<Props, FileViewModel>({
    mapPropsToValues: props => {
        let response = new FileViewModel();
		response.setProperties(props.model!.bucketId,props.model!.dateCreated,props.model!.description,props.model!.expiration,props.model!.extension,props.model!.externalId,props.model!.fileSizeInByte,props.model!.fileTypeId,props.model!.id,props.model!.location,props.model!.privateKey,props.model!.publicKey);	
		return response;
      },
  
    // Custom sync validation
    validate: values => {
      let errors:FormikErrors<FileViewModel> = { };

	  if(values.dateCreated == undefined) {
                errors.dateCreated = "Required"
                    }if(values.expiration == undefined) {
                errors.expiration = "Required"
                    }if(values.extension == '') {
                errors.extension = "Required"
                    }if(values.externalId == undefined) {
                errors.externalId = "Required"
                    }if(values.fileSizeInByte == 0) {
                errors.fileSizeInByte = "Required"
                    }if(values.fileTypeId == 0) {
                errors.fileTypeId = "Required"
                    }if(values.id == 0) {
                errors.id = "Required"
                    }if(values.location == '') {
                errors.location = "Required"
                    }if(values.privateKey == '') {
                errors.privateKey = "Required"
                    }if(values.publicKey == '') {
                errors.publicKey = "Required"
                    }

      return errors;
    },
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
		  
	    let mapper = new FileMapper();

        axios.put(Constants.ApiEndpoint + ApiRoutes.Files +'/' + values.id,
           
	    mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as UpdateResponse<Api.FileClientRequestModel>;
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
  
    displayName: 'FileEdit', 
  })(FileEditDisplay);

 
  interface IParams 
  {
     id:number;
  }

  interface IMatch
  {
     params: IParams;
  }
  
  interface FileEditComponentProps
  {
     match:IMatch;
  }

  interface FileEditComponentState
  {
      model?:FileViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class FileEditComponent extends React.Component<FileEditComponentProps, FileEditComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Files + '/' + this.props.match.params.id, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.FileClientResponseModel;
            
            console.log(response);

			let mapper = new FileMapper();

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
            return (<FileEdit model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>d9f6eeb3447ccf6cce39fd5c746ffb04</Hash>
</Codenesium>*/